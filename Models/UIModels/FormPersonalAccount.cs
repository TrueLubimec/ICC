using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.UIModels
{
    internal class FormPersonalAccount
    {
        public int PersonalAccountID { get; set; }

        [Display(Name = "Object address")]
        [Required(ErrorMessage = "Please enter the address!")]
        [MinLength(1, ErrorMessage = "Invalid name")] //стоит переработать эту валидацию
        public string Address { get; set; }

        public int Square { get; set; }

        public string Residents { get; set; }
    }
}
