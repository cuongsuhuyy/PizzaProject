using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace BEPizza.Models
{
    public class OrderDetails
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int PizzaID { get; set; }
        public int UserID { get; set; }
        public Order Order { get; set; }
        public User User { get; set; }
        public Pizza Pizza { get; set; }
    }
}
