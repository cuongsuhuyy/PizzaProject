using BEPizza.Models;

namespace BEPizza.Repositories.Interfaces
{
    public interface IOrderDetailsRepository
    {
        IEnumerable<OrderDetails> GetAllOrderDetails();
        OrderDetails GetOrderDetailsById(int id);
        void AddOrderDetails(OrderDetails orderDetails);
        void UpdateOrderDetails(OrderDetails orderDetails);
        void DeleteOrderDetails(int id);
    }
}
