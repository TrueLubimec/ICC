using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DtOs
{
    internal class PersonalAccountDto
    {
        public int Id { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Address { get; set; }
        public int Square { get; set; }
        public string Residents { get; set; }
    }
}
