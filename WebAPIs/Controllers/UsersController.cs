using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            _userService.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.user_id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.user_id)
            {
                return BadRequest();
            }

            _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(id);
            return NoContent();
        }

        [HttpGet("byemail")]
        public IActionResult GetUserByEmail(string email)
        {
            var user = _userService.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
