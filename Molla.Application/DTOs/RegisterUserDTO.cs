using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molla.Application.DTOs
{
    public class RegisterUserDTO
    {
        public Guid ID { get; set; }
        [Required]
        [MaxLength(250)]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Phone number")]
/*        [RegularExpression("09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}", ErrorMessage = "Please enter valid phone no.")]
*/        [Required(ErrorMessage = "please enter {0}")]
        public string PhoneNum { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string RePassword { get; set; }
    }
}
