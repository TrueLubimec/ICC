using System;

namespace ICC.Models.DtOs
{
    public class PersonalAccToUpdateDto
    {
        public int Id { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Address { get; set; }
        public int Square { get; set; }
        public string Residents { get; set; }
    }
}
