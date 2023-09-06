using BEPizza.Models;

namespace BEPizza.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrder();
        Order GetOrderById(string id);
        Order CreateOrder(string pizzaId, string userId);
    }
}
