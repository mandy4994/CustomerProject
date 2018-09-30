using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerProject.Models
{
    public class CustomerListViewModel
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = @"{0:dd\/MM\/yyyy}")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Customer Code")]
        public string CustCode { get; set; }
    }
}
