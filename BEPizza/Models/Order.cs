namespace BEPizza.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string OrderID { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; } = new List<OrderDetails>();
    }
}
