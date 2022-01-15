using System.ComponentModel.DataAnnotations;

namespace CoomingSoon.Models
{
    public class Subscribe
    {
        public int Id { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
