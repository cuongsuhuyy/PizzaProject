using BEPizza.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace BEPizza.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly PizzaContext _dbContext;

        public OrderController(PizzaContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("[Action]")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrder() 
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            return await _dbContext.Order.ToListAsync();
        }

        [HttpGet("[Action]/orderId")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderById(string orderId)
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            return await _dbContext.Order.Where(e => e.OrderID == orderId).ToListAsync();
        }

        [HttpPost("[Action]")]
        public async Task<ActionResult<Order>> CreateNewOrder(string pizzaId, string userId)
        {
            if (_dbContext == null)
            {
                return NotFound();
            }

            Guid guid = Guid.NewGuid();
            string randomString = guid.ToString("N").Substring(0, 8);

            var order = new Order()
            {
                OrderID = guid.ToString(),
                DateCreated = DateTime.Now
            };
            string orderId = order.OrderID;
            _dbContext.Order.Add(order);
            _dbContext.SaveChanges();

            order = _dbContext.Order.FirstOrDefault(e => e.OrderID == orderId);
            var pizza = _dbContext.Pizza.FirstOrDefault(e => e.PizzaID == pizzaId);
            var user = _dbContext.User.FirstOrDefault(e => e.UserID == userId);

            if (user == null)
            {
                return BadRequest("user is null");
            }

            if (pizza == null)
            {
                return BadRequest("pizza is null");
            }

            if (order == null)
            {
                return BadRequest("order is null");
            }

            var orderDetails = new OrderDetails()
            {
                OrderID = order.ID,
                PizzaID = pizza.ID,
                UserID = user.ID
            };
            _dbContext.OrderDetails.Add(orderDetails);
            _dbContext.SaveChanges();

            var jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve // Handle circular references
            };

            return new ContentResult
            {
                Content = JsonSerializer.Serialize(order, jsonOptions),
                ContentType = "application/json"
            };
        }

    }
}
