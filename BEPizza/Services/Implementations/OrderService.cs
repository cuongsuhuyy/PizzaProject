using BEPizza.Models;
using BEPizza.Repositories.Interfaces;
using BEPizza.Services.Interfaces;

namespace BEPizza.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order CreateOrder(string pizzaId, string userId)
        {
            return _orderRepository.CreateOrder(pizzaId, userId);
        }

        public IEnumerable<Order> GetAllOrder()
        {
            return _orderRepository.GetAllOrder();
        }

        public Order GetOrderById(string id)
        {
            try
            {
                return _orderRepository.GetOrderById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
