using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerProject.Models
{
    public class CustomerViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "The First Name cannot be empty.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "The Last Name cannot be empty.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The Email cannot be empty.")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
    }
}
