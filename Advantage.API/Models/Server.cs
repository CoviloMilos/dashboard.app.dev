using System.ComponentModel.DataAnnotations;

namespace Advantage.API.Models
{
    public class Server
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOnline { get; set; }
    }
}