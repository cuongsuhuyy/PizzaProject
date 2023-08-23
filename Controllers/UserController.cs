using BEPizza.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEPizza.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly PizzaContext _dbContext;

        public UserController(PizzaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUser()
        {
            if (_dbContext == null)
            {
                return NotFound();
            }
            return await _dbContext.User.ToListAsync();
        }

        [HttpGet("[action]/{userId}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserById(string userId)
        {
            if (_dbContext == null)
            {
                return NotFound();
            }
            return await _dbContext.User.Where(x => x.UserID == userId).ToListAsync();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<User>> InsertUser(User user)
        {
            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<User>> DeleteUserById(string userId)
        {
            var listUser = _dbContext.User.Where(x => x.UserID == userId).ToList();
            _dbContext.User.RemoveRange(listUser);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<User>> UpdateUserById(User user)
        {
            var listUser = _dbContext.User.Where(x => x.UserID == user.UserID).ToList();
            foreach (var item in listUser)
            {
                item.UserName = user.UserName;
                item.Password = user.Password;
                item.PhoneNumber = user.PhoneNumber;
                item.Email = user.Email;
                item.TypeID = user.TypeID;
            }
            _dbContext.User.UpdateRange(listUser);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
