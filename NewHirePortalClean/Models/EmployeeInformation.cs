using System;
using System.ComponentModel.DataAnnotations;

namespace NewHirePortalClean.Models
{
    public class EmployeeInformation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string PhoneNumber2 { get; set; }

        // Add additional fields if needed...
    }
}
