using BEPizza.Models;
using BEPizza.Services.Implementations;
using BEPizza.Services.Interfaces;
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
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet("[action]")]
        public ActionResult<Pizza> GetAllPizza()
        {
            var pizzaList = _pizzaService.GetAllPizza();
            return Ok(pizzaList);
        }

        [HttpGet("[action]/{pizzaId}")]
        public ActionResult<Pizza> GetPizzaById(string pizzaId)
        {
            var pizza = _pizzaService.GetPizzaById(pizzaId);
            if (pizza == null) 
            {
                return NotFound();
            }

            return Ok(pizza);
        }

        [HttpPost("[action]")]
        public IActionResult InsertPizza(Pizza pizza)
        {
            _pizzaService.AddPizza(pizza);
            var url = Url.Action(nameof(GetPizzaById), new {pizzaId = pizza.PizzaID });
            if (url == null)
            {
                return NoContent();
            }

            return Created(url, pizza);
        }

        [HttpDelete("[action]")]
        public IActionResult DeletePizzaById(string pizzaId)
        {
            _pizzaService.DeletePizza(pizzaId);
            return NoContent();
        }

        [HttpPut("[action]")]
        public IActionResult UpdatePizzaById(Pizza pizza)
        {
            _pizzaService.UpdatePizza(pizza);
            var url = Url.Action(nameof(GetPizzaById), new { pizzaId = pizza.PizzaID });
            if (url == null) 
            {
                return NoContent();
            }

            return Created(url, pizza);
        }
    }
}
