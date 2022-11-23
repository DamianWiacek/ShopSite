using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopSite.Entities;
using ShopSite.Exceptions;
using ShopSite.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShopSite.Services
{
    public interface IUserService
    {
        public UserDto GetById(int id);
        public List<UserDto> GetAll();
        public int Create(NewUserDto newUserDto);
        public bool Delete(int userId);
        public string GenerateJwt(LoginDto loginDto);

    }
    public class UserService : IUserService
    {
        private readonly ShopDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public UserService(ShopDbContext dbContext, IMapper mapper, ILogger<UserService> logger, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public UserDto GetById(int id)
        {
            var user = _dbContext.Users.Include(r=>r.Adres).SingleOrDefault(x => x.Id == id);

            if (user == null) return null;
            var result = _mapper.Map<UserDto>(user);
            return result; 
        }

        public List<UserDto> GetAll()
        {
            var users = _dbContext.Users.Include(r=>r.Adres).ToList();

            var result = _mapper.Map<List<UserDto>>(users);
            return result;
        }

        public int Create(NewUserDto newUserDto)
        {
            var newUser = _mapper.Map<User>(newUserDto);
            var hashedPasswd = _passwordHasher.HashPassword(newUser, newUserDto.Password);
            newUser.PasswordHash = hashedPasswd;
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            


            return newUser.Id;

        }

        public bool Delete(int id)
        {
            var user = _dbContext.Users.Include(r => r.Adres).SingleOrDefault(x => x.Id == id);
            if (user == null)
            {
                return false;
            }
            _dbContext.Remove(user);
            _dbContext.SaveChanges();
            return true;
            
        }

        public string GenerateJwt(LoginDto loginDto)
        {
            var user = _dbContext.Users.Include(x=>x.Role).FirstOrDefault(x => x.Email == loginDto.Email);
            if (user == null)
            {
                throw new BadRequestException("Invalid username or password");
            }

           var result =  _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");

            }
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.Name} {user.Surname}"),
                new Claim(ClaimTypes.Role,user.Role.Name),
                new Claim("Age",user.Age.ToString()),
                new Claim("Nationality",user.Nationality),


            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
