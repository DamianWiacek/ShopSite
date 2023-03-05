using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ShopSite.Entities;
using ShopSite.Repositories;
using ShopSite;
using ShopSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ShopSite.Models;

namespace Tests.UnitTests
{
    public class UserServiceTests
    {
        private UserService _service;
        private readonly Mock<IUserRepository> _repository = new();
        private readonly Mock<IMapper> _mapper = new();
        private readonly Mock<ILogger<UserService>> _logger = new();
        private readonly Mock<IPasswordHasher<User>> _passwordHasher = new();
        private readonly Mock<AuthenticationSettings> _authenticationSettings = new();
        public UserServiceTests()
        {
            _service = new(
                _repository.Object,
                _mapper.Object,
                _logger.Object,
                _passwordHasher.Object,
                _authenticationSettings.Object);
        }

        //public async Task<UserDto> GetByEmail(string email)
        //{
        //    var user = await _repository.GetByEmail(email);

        //    if (user == null) return null;
        //    var result = _mapper.Map<UserDto>(user);
        //    return result;
        //}

        public Task GetByEmail_ForCorrectEmail_ReturnUserDto()
        {
            //Arrange
            var email = "test@email.com";
            var user = new User() { Email = email };
            _repository.Setup(r => r.GetByEmail(email)).Returns(user);

            //Act
            var result = await _service.GetByEmail(email);
        }
    }
}
