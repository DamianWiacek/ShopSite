using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ShopSite.Entities;
using ShopSite.Exceptions;
using ShopSite.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopSite.Repositories
{
    public interface IUserRepository
    {
        public Task<User> GetByEmail(string email);
        public Task<List<User>> GetAll();
        public Task Create(User user);
        public Task Delete(int userId);
        public Task<User> GetUserFromLoginDto(LoginDto loginDto);

    }
    public class UserRepository : IUserRepository
    {
        private readonly ShopDbContext _dbContext;
   
        public UserRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _dbContext.Users.Include(r => r.Adres).SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Users.Include(r => r.Adres).ToListAsync();

        }

        public async Task Create(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();


        }

        public async Task Delete(int id)
        {
            var user = await _dbContext.Users.Include(r => r.Adres).SingleOrDefaultAsync(x => x.Id == id);
            _dbContext.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<User> GetUserFromLoginDto(LoginDto loginDto)
        {
            return await _dbContext.Users.Include(x => x.Role).FirstOrDefaultAsync(x => x.Email == loginDto.Email);
        }


        }
}
