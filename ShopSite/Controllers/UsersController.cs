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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
            
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            return _userService.GetAll();
        }
        
        [HttpGet("{email}")]
        public UserDto GetById([FromRoute] string email)
        {
            return _userService.GetByEmail(email);
        }
        
        [HttpPost]
        public ActionResult CreateUser([FromBody] NewUserDto newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _userService.Create(newUser);
            return Created($"/api/UserController/{id}",null);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteUser([FromRoute] int id)
        {
            var isDeleted = _userService.Delete(id);
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody]LoginDto loginDto)
        {
            string token = _userService.GenerateJwt(loginDto);
            return Ok(token);
        }

    }
}
