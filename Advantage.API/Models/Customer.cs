using System.ComponentModel.DataAnnotations;

namespace Advantage.API.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string CustomerRole { get; set; }
    }
}