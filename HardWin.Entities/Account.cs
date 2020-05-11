using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardWin.Entities
{
    public class Account
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter first name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Display(Name = "Phone No")]
        [Required(ErrorMessage = "Please enter Phone No.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please enter Address.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter Country.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter State.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter amount.")]
        public Decimal Amount { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
