using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class AppItem
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Polje naziv je obavezno")]
        [StringLength(20,ErrorMessage = "Naziv ne može biti duži od 20 znakova")]
        public string name { get; set; }

        [Required(ErrorMessage = "Polje jedinica mjere je obavezno")]
        public string unitOfMeasure { get; set; }

        [Required(ErrorMessage = "Polje količina je obavezno")]
        public float quantity { get; set; }

        [Required(ErrorMessage = "Polje cijena bez PDV-a je obavezno")]
        public float nettoPrice { get; set; }

        [Required(ErrorMessage = "Polje PDV je obavezno")]
        public float VAT { get; set; }

        public AppBill Bill { get; set; }

        public int BillId { get; set; }
    } 
}