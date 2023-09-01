using BEPizza.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEPizza.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SizePizzaController : ControllerBase
    {
        private readonly PizzaContext _dbContext;

        public SizePizzaController(PizzaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<SizePizza>>> GetAllSizePizza()
        {
            if (_dbContext == null)
            {
                return NotFound();
            }
            return await _dbContext.SizePizza.ToListAsync();
        }

        [HttpGet("[action]/{sizePizzaId}")]
        public async Task<ActionResult<IEnumerable<SizePizza>>> GetSizePizzaById(string sizeId)
        {
            if (_dbContext == null)
            {
                return NotFound();
            }
            return await _dbContext.SizePizza.Where(x => x.SizeID == sizeId).ToListAsync();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<SizePizza>> InsertSizePizza(SizePizza sizePizza)
        {
            _dbContext.SizePizza.Add(sizePizza);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<SizePizza>> DeleteSizePizzaById(string sizeId)
        {
            var listSizePizza = _dbContext.SizePizza.Where(x => x.SizeID == sizeId).ToList();
            _dbContext.SizePizza.RemoveRange(listSizePizza);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<SizePizza>> UpdateSizePizzaById(SizePizza sizePizza)
        {
            var listSizePizza = _dbContext.SizePizza.Where(x => x.SizeID == sizePizza.SizeID).ToList();
            foreach (var item in listSizePizza)
            {
                item.SizeName = sizePizza.SizeName;
            }
            _dbContext.SizePizza.UpdateRange(listSizePizza);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
