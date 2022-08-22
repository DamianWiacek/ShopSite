using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopSite.Entities;
using ShopSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
    public class UserService : IUserService
    {
        private readonly ShopDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserService(ShopDbContext dbContext, IMapper mapper, ILogger<UserService> logger, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _passwordHasher = passwordHasher;
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
            
    }
}
