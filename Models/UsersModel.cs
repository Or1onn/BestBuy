using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LoginPanel.Models
{
    public class UsersModel
    {
        [Key]
        public int Id{ get; set; }
        [Required]
        public string? Login { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Email { get; set; }
    }
}
