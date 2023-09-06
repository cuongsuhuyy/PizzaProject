using BEPizza.Models;

namespace BEPizza.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAllOrder();
        Order GetOrderById(string id);
        Order CreateOrder(string pizzaId, string userId);
    }
}
