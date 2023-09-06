using BEPizza.Models;
using BEPizza.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEPizza.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        public ActionResult<User> GetAllUser()
        {
            var listUser = _userService.GetAllUser();
            if (listUser == null)
            {
                return NotFound();
            }
            return Ok(listUser);
        }

        [HttpGet("[action]/{userId}")]
        public ActionResult<User> GetUserById(string userId)
        {
            var user = _userService.GetUserById(userId);
            if (user == null) 
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost("[action]")]
        public IActionResult InsertUser(User user)
        {
            _userService.AddUser(user);

            // Generate the URL for the newly created resource (user)
            var url = Url.Action(nameof(GetUserById), new { userId = user.UserID });

            if (url == null) 
            {
                return NoContent();
            }
            // Return a response with a 201 Created status code and the Location header set
            return Created(url, user);
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteUserById(string userId)
        {
            _userService.DeleteUser(userId);
            return NoContent();
        }

        [HttpPut("[action]")]
        public IActionResult UpdateUserById(User user)
        {
            _userService.UpdateUser(user);
            var url = Url.Action(nameof(GetUserById), new { userId = user.UserID });

            if (url == null) 
            {
                return NoContent();
            }

            return Created(url, user);
        }
    }
}
