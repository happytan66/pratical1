using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pratical1.Models
{
    public class DisplayPersonModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "First Name is too long !!")]
        [MinLength(2, ErrorMessage = "First Name is too short")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Last Name is too long !!")]
        [MinLength(2, ErrorMessage = "Last Name is too short")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddreess { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string password { get; set; }
       
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(password))]
        [NotMapped]
        public string Confirmpassword { get; set; }

 
    }
}
