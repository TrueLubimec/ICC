using System.ComponentModel.DataAnnotations.Schema;

namespace ICC.Api.Entities
{
    public class Resident
    {
        public int Id { get; set; }
        public int PersonalAccountId { get; set; }
        [ForeignKey("PersonalAccountId")]
        public PersonalAccount PersonalAccount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
