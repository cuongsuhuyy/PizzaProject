using BEPizza.Models;
using BEPizza.Repositories.Interfaces;

namespace BEPizza.Repositories.Implementations
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private readonly PizzaContext _dbContext;

        public OrderDetailsRepository(PizzaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddOrderDetails(OrderDetails orderDetails)
        {
            _dbContext.OrderDetails.Add(orderDetails);
            _dbContext.SaveChanges();
        }

        public void DeleteOrderDetails(int id)
        {
            try
            {
                var OrderDetails = GetOrderDetailsById(id);
                if (OrderDetails != null)
                {
                    _dbContext.OrderDetails.Remove(OrderDetails);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Can not find OrderDetailsId!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<OrderDetails> GetAllOrderDetails()
        {
            return _dbContext.OrderDetails.ToList();
        }

        public OrderDetails GetOrderDetailsById(int id)
        {
            try
            {
                var OrderDetails = _dbContext.OrderDetails.FirstOrDefault(x => x.OrderID == id);
                if (OrderDetails != null)
                {
                    return OrderDetails;
                }
                else
                {
                    throw new Exception("Can not find OrderDetails!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateOrderDetails(OrderDetails orderDetails)
        {
            try
            {
                _dbContext.OrderDetails.Update(orderDetails);
                _dbContext.SaveChanges(true);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
