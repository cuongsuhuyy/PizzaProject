using BEPizza.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using BEPizza.Services.Interfaces;

namespace BEPizza.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("[Action]")]
        public ActionResult<Order> GetAllOrder() 
        {
            var orderList = _orderService.GetAllOrder();
            return Ok(orderList);
        }

        [HttpGet("[Action]/orderId")]
        public ActionResult<Order> GetOrderById(string orderId)
        {
            var order = _orderService.GetOrderById(orderId);
            return Ok(order);
        }

        [HttpPost("[Action]")]
        public IActionResult CreateNewOrder(string pizzaId, string userId)
        {
            var order = _orderService.CreateOrder(pizzaId, userId);
            var url = Url.Action(nameof(GetOrderById), new { orderId = order.OrderID });
            if (url == null)
            {
                return NoContent();
            }

            return Created(url, order);
        }

    }
}
