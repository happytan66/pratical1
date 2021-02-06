using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pratical1.Models
{
    public class DisplayPersonModel : IPersonModel
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
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [NotMapped]
        public string Confirmpassword { get; set; }

 
    }
}
