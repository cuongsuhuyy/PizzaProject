using BEPizza.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace BEPizza.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaContext _dbContext;

        public PizzaController(PizzaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetAllPizza()
        {
            if (_dbContext == null)
            {
                return NotFound();
            }
            return await _dbContext.Pizza.ToListAsync();
        }

        [HttpGet("[action]/{pizzaId}")]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzaById(string pizzaId)
        {
            if (_dbContext == null)
            {
                return NotFound();
            }
            return await _dbContext.Pizza.Where(x => x.PizzaID == pizzaId).ToListAsync();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Pizza>> InsertPizza(Pizza pizza)
        {
            _dbContext.Pizza.Add(pizza);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<Pizza>> DeletePizzaById(string pizzaId)
        {
            var listPizza = _dbContext.Pizza.Where(x => x.PizzaID == pizzaId).ToList();
            _dbContext.Pizza.RemoveRange(listPizza);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<Pizza>> UpdatePizzaById(Pizza pizza)
        {
            var listPizza = _dbContext.Pizza.Where(x => x.PizzaID == pizza.PizzaID).ToList();
            foreach (var item in listPizza) 
            {
                item.PizzaID = pizza.PizzaID;
                item.PizzaName = pizza.PizzaName;
                item.Description = pizza.Description;
                item.Price = pizza.Price;
            }
            _dbContext.Pizza.UpdateRange(listPizza);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
