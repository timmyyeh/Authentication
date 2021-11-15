using System.ComponentModel.DataAnnotations;

namespace authentication
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}