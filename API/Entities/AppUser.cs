using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class AppUser
    {
        public int id { get; set; }

        public bool isMasterAdmin { get; set; }
    
        [Required(ErrorMessage = "Polje ime je obavezno")]
        [StringLength(20,ErrorMessage = "Ime ne može biti duže od 20 znakova")]
        public string name { get; set; }

        [Required(ErrorMessage = "Polje prezime je obavezno")]
        [StringLength(20,ErrorMessage = "Prezime ne može biti duže od 20 znakova")]
        public string surname { get; set; }

        [Required(ErrorMessage = "Polje korisničko ime je obavezno")]
        [StringLength(20,ErrorMessage = "Korisničko ime ne može biti duže od 20 znakova")]
        public string username { get; set; }

        public byte[] passwordHash { get; set; }

        public byte[] passwordSalt { get; set; }

        [Required(ErrorMessage = "Polje email je obavezno")]
        [StringLength(40,ErrorMessage = "Email ne može biti duži od 40 znakova")]
        public string email { get; set; }

        [Required(ErrorMessage = "Polje naziv firme je obavezno")]
        [StringLength(20,ErrorMessage = "Naziv firme ne može biti duži od 20 znakova")]
        public string companyName { get; set; }

        [Required(ErrorMessage = "Polje adresa firme je obavezno")]
        [StringLength(40,ErrorMessage = "Adresa ne može biti duža od 40 znakova")]
        public string companyAdress { get; set; }

        [Required(ErrorMessage = "Polje poštanski broj je obavezno")]
        public int zipCode { get; set; }

        [Required(ErrorMessage = "Polje mjesto firme je obavezno")]
        [StringLength(40,ErrorMessage = "Mjesto ne može biti duže od 40 znakova")]
        public string companyCity { get; set; } 

        [JsonIgnore]
        public virtual ICollection<AppBill> Bills { get; set; }

    }
}