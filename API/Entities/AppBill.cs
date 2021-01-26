using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class AppBill
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Polje datum dokumenta je obavezno")]
        [Column(TypeName = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public string billDate { get; set; }

        [Required(ErrorMessage = "Polje datum valute je obavezno")]
        [Column(TypeName = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public string currencyDate { get; set; }

        [Required(ErrorMessage = "Polje ime partnera je obavezno")]
        [StringLength(40,ErrorMessage = "Ime partnera ne može biti duže od 40 znakova")]
        public string partnerName { get; set; }

        [Required(ErrorMessage = "Polje adresa partnera je obavezno")]
        [StringLength(40,ErrorMessage = "Adresa partnera ne može biti duža od 40 znakova")]
        public string partnerAdress { get; set; }

        [Required(ErrorMessage = "Polje poštanski broj je obavezno")]
        public int partnerZipCode { get; set; }

        [Required(ErrorMessage = "Polje mjesto partnera je obavezno")]
        [StringLength(40,ErrorMessage = "Mjesto partnera ne može biti duže od 40 znakova")]
        public string partnerCity { get; set; }

        [StringLength(200,ErrorMessage = "Opis ne može biti duži od 200 znakova")]
        public string description { get; set; }

        [Column("UserId")]
        public int AppUserid { get; set; }

        [JsonIgnore]
        public virtual ICollection<AppItem> Items { get; set; }
    }
}