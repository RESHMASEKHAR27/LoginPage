using System.ComponentModel.DataAnnotations;

namespace LoginPage.Models
{
    public class User
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
