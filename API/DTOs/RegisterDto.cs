using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDto
    {

        public bool IsMasterAdmin { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Surname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string CompanyAdress { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public string CompanyCity { get; set; }
    }
}