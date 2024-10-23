using System.ComponentModel.DataAnnotations;

namespace NewHirePortalClean.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"\d{5}", ErrorMessage = "Invalid Zip-code")]
        public string ZipCode { get; set; }

        // EmployeeInformation fields added to Address
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
    }
}
