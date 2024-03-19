using System;

namespace ICC.Models.DtOs
{
    public class PersonalAccToAddDto
    {
        public DateTime EffectiveDate { get; set; }
        public string Address { get; set; }
        public int Square { get; set; }
        public string Residents { get; set; }
    }
}
