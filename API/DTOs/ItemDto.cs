using API.Entities;

namespace API.DTOs
{
    public class ItemDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string unitOfMeasure { get; set; }
        public float quantity { get; set; }
        public float nettoPrice { get; set; }
        public float VAT { get; set; }
        public int BillId { get; set; }
    }
}