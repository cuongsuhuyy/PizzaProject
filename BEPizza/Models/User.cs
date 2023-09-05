using Azure.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BEPizza.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public int TypeID { get; set; }
        [JsonIgnore]
        public TypeUser? TypeUser { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; } = new List<OrderDetails>();
    }
}
