using System;
using System.ComponentModel.DataAnnotations;

namespace NewHirePortalClean.Models
{
    public class PersonalInformation
    {
        [Key]  // Primary key added
        public int Id { get; set; }  // Primary key property

        [Required]
        public string FullName { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"\d{5}", ErrorMessage = "Invalid Zip-code")]
        public string ZipCode { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DateAvailable { get; set; }

        [Required]
        [RegularExpression(@"\d{3}-\d{2}-\d{4}", ErrorMessage = "Invalid Social Security Number format")]
        public string SocialSecurity { get; set; }

        public string DesiredSalary { get; set; }

        [Required]
        public string PositionAppliedFor { get; set; }

        [Required]
        public string UsCitizen { get; set; }

        public string ExplainCitizen { get; set; }
    }
}
