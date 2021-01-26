using System.Collections.Generic;
using System.Text.Json.Serialization;
using API.Entities;

namespace API.DTOs
{
    public class BillDto
    {
        public int id { get; set; }
        public string billDate { get; set; }
        public string currencyDate { get; set; }
        public string partnerName { get; set; }
        public string partnerAdress { get; set; }
        public int partnerZipCode { get; set; }
        public string partnerCity { get; set; }
        public string description { get; set; }
        public int UserId { get; set; }

        // [JsonIgnore]
        public virtual ICollection<ItemDto> Items { get; set; }
    }
}