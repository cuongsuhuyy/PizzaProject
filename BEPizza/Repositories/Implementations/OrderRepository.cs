using BEPizza.Models;
using BEPizza.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace BEPizza.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PizzaContext _dbContext;

        public OrderRepository(PizzaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Order CreateOrder(string pizzaId, string userId)
        {
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
                throw new Exception("User is null!");
            }

            if (pizza == null)
            {
                throw new Exception("Pizza is null!");
            }

            if (order == null)
            {
                throw new Exception("Order is null!");
            }

            var orderDetails = new OrderDetails()
            {
                OrderID = order.ID,
                PizzaID = pizza.ID,
                UserID = user.ID
            };
            _dbContext.OrderDetails.Add(orderDetails);
            _dbContext.SaveChanges();

            //var jsonOptions = new JsonSerializerOptions
            //{
            //    ReferenceHandler = ReferenceHandler.Preserve // Handle circular references
            //};

            return order;
        }

        public IEnumerable<Order> GetAllOrder()
        {
            return _dbContext.Order.ToList();
        }

        public Order GetOrderById(string id)
        {
            try
            {
                var Order = _dbContext.Order.FirstOrDefault(x => x.OrderID == id);
                if (Order != null)
                {
                    return Order;
                }
                else
                {
                    throw new Exception("Can not find Order!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
