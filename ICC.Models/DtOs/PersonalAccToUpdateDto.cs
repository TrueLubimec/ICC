using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
