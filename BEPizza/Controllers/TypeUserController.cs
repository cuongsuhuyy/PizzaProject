using BEPizza.Models;
using BEPizza.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BEPizza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeUserController : ControllerBase
    {
        private readonly ITypeUserService _typeUserService;

        public TypeUserController(ITypeUserService typeUserService)
        {
            _typeUserService = typeUserService;
        }

        [HttpGet("[action]")]
        public ActionResult<TypeUser> GetAllTypeUser()
        {
            var typeUserList = _typeUserService.GetAllTypeUser();
            if (typeUserList == null) 
            {
                return NotFound();
            }

            return Ok(typeUserList);
        }

        [HttpGet("[action]/{typeId}")]
        public ActionResult<TypeUser> GetTypeUserById(string typeId)
        {
            var typeUser = _typeUserService.GetTypeUserById(typeId);
            if (typeUser == null) 
            {
                return NotFound();
            }

            return Ok(typeUser);
        }

        [HttpPost("[action]")]
        public IActionResult InsertTypeUser(TypeUser typeUser)
        {
            _typeUserService.AddTypeUser(typeUser);
            var url = Url.Action(nameof(GetTypeUserById), new { typeId = typeUser.TypeID });
            if (url == null) 
            {
                return NoContent();
            }

            return Created(url, typeUser);
        }

        [HttpDelete("[action]")]
        public IActionResult DeleteTypeUserById(string typeId)
        {
            _typeUserService.DeleteTypeUser(typeId);
            return NoContent();
        }

        [HttpPut("[action]")]
        public IActionResult UpdateTypeUserById(TypeUser typeUser)
        {
            _typeUserService.UpdateTypeUser(typeUser);
            var url = Url.Action(nameof(GetTypeUserById), new { typeId = typeUser.TypeID });
            if (url != null)
            {
                return NoContent();
            }

            return Created(url, typeUser);
        }
    }
}
