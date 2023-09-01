using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BEPizza.Models
{
    public class SizePizza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string SizeID { get; set; }
        public string SizeName { get; set; }
        public ICollection<Pizza> Pizzas { get; } = new List<Pizza>();
    }
}
