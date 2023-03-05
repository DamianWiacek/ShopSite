using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopSite.Entities;
using ShopSite.Models;
using ShopSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSite.Controllers
{
    [Route("api/UserController")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
            
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            return await _userService.GetAll();
        }
        
        [HttpGet("{email}")]
        [Authorize(Roles = "Admin")]
        public async Task<UserDto> GetById([FromRoute] string email)
        {
            return await _userService.GetByEmail(email);
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] NewUserDto newUser)
        {
 
            var id = await _userService.Create(newUser);
            return Created($"/api/UserController/{id}",null);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {
            await _userService.Delete(id);
            return NotFound();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody]LoginDto loginDto)
        {
            string token = await _userService.GenerateJwt(loginDto);
            return Ok(token);
        }

    }
}
