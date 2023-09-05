using BEPizza.Models;
using BEPizza.Services.Implementations;
using BEPizza.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEPizza.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SizePizzaController : ControllerBase
    {
        private readonly ISizePizzaService _sizePizzaService;

        public SizePizzaController(ISizePizzaService sizePizzaService)
        {
            _sizePizzaService = sizePizzaService;
        }

        [HttpGet("[action]")]
        public ActionResult<SizePizza> GetAllSizePizza()
        {
            var sizePizzaList = _sizePizzaService.GetAllSizePizza();
            return Ok(sizePizzaList);
        }

        [HttpGet("[action]/{sizePizzaId}")]
        public ActionResult<SizePizza> GetSizePizzaById(string sizeId)
        {
            var sizePizza = _sizePizzaService.GetSizePizzaById(sizeId);
            if (sizePizza == null) 
            {
                return NotFound();
            }

            return Ok(sizePizza);
        }

        [HttpPost("[action]")]
        public IActionResult InsertSizePizza(SizePizza sizePizza)
        {
            _sizePizzaService.AddSizePizza(sizePizza);
            var url = Url.Action(nameof(GetSizePizzaById), new { sizeId = sizePizza.SizeID });
            if (url == null)
            {
                return NoContent();
            }

            return Created(url, sizePizza);
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteSizePizzaById(string sizeId)
        {
            _sizePizzaService.DeleteSizePizza(sizeId);
            return NoContent();
        }

        [HttpPut("[action]")]
        public IActionResult UpdateSizePizzaById(SizePizza sizePizza)
        {
            _sizePizzaService.UpdateSizePizza(sizePizza);
            var url = Url.Action(nameof(GetSizePizzaById), new { sizeId = sizePizza.SizeID });
            if (url == null)
            {
                return NoContent();
            }

            return Created(url, sizePizza);
        }
    }
}
