using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEPizza.Models
{
    public class Pizza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string PizzaID { get; set; }
        public string PizzaName { get; set; }
        public string? Description { get; set; }
        public long Price { get; set; }
    }
}
