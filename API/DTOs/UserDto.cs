using System.Collections.Generic;

namespace API.DTOs
{
    public class UserDto
    {
        public int id { get; set; }
        public bool isMasterAdmin { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string companyName { get; set; }
        public string companyAdress { get; set; }
        public int zipCode { get; set; }
        public string companyCity { get; set; } 
        public virtual ICollection<BillDto> Bills { get; set; }
    }
}