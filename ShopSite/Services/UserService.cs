using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopSite.Entities;
using ShopSite.Exceptions;
using ShopSite.Models;
using ShopSite.Repositories;
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
        public Task<UserDto> GetByEmail(string email);
        public Task<List<UserDto>> GetAll();
        public Task<int> Create(NewUserDto newUserDto);
        public Task Delete(int userId);
        public Task<string> GenerateJwt(LoginDto loginDto);

    }
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;

        public UserService(IUserRepository repository, IMapper mapper, ILogger<UserService> logger, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            var user = await _repository.GetByEmail(email);

            if (user == null) return null;
            var result = _mapper.Map<UserDto>(user);
            return result; 
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await _repository.GetAll();

            var result = _mapper.Map<List<UserDto>>(users);
            return result;
        }

        public async Task<int> Create(NewUserDto newUserDto)
        {
            var newUser = _mapper.Map<User>(newUserDto);

            var hashedPasswd = _passwordHasher.HashPassword(newUser, newUserDto.Password);
            newUser.PasswordHash = hashedPasswd;

            await _repository.Create(newUser);
            
            return newUser.Id;

        }

        public async Task Delete(int id)
        {
            _repository.Delete(id);
            
        }

        public async Task<string> GenerateJwt(LoginDto loginDto)
        {
            var user = await _repository.GetUserFromLoginDto(loginDto);
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
