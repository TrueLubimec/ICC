using System;

namespace ICC.Api.Entities
{
    public class PersonalAccount
    {
        public int Id { get; set; }
        public string AccountNum { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Address { get; set; }
        public int Square { get; set; } //унифицированно используют квадраты для определения площади, поэтому отткаликвался, что в db заполняют метры квадратные
        public string Residents { get; set; }
    }
}
