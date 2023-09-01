using BEPizza.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeUserController : ControllerBase
    {
        private readonly PizzaContext _dbContext;

        public TypeUserController(PizzaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<TypeUser>>> GetAllTypeUser()
        {
            if (_dbContext == null)
            {
                return NotFound();
            }
            return await _dbContext.TypeUser.ToListAsync();
        }

        [HttpGet("[action]/{typeId}")]
        public async Task<ActionResult<IEnumerable<TypeUser>>> GetTypeUserById(string typeId)
        {
            if (_dbContext == null)
            {
                return NotFound();
            }
            return await _dbContext.TypeUser.Where(x => x.TypeID == typeId).ToListAsync();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<TypeUser>> InsertTypeUser(TypeUser typeUser)
        {
            _dbContext.TypeUser.Add(typeUser);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<TypeUser>> DeleteTypeUserById(string typeId)
        {
            var listTypeUser = _dbContext.TypeUser.Where(x => x.TypeID == typeId).ToList();
            _dbContext.TypeUser.RemoveRange(listTypeUser);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<TypeUser>> UpdateTypeUserById(TypeUser typeUser)
        {
            var listTypeUser = _dbContext.TypeUser.Where(x => x.TypeID == typeUser.TypeID).ToList();
            foreach (var item in listTypeUser)
            {
                item.TypeName = typeUser.TypeName;
            }
            _dbContext.TypeUser.UpdateRange(listTypeUser);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
