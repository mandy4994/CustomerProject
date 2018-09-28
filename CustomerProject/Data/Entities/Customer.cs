using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerProject.Data
{
    public class Customer
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CustCode { get; set; }
    }
}