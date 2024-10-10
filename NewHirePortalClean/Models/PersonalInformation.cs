using System;
using System.ComponentModel.DataAnnotations;

namespace NewHirePortalClean.Models
{
    public class PersonalInformation
    {
        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string CurrentAddress { get; set; }

        [Required]
        public DateTime DateAvailable { get; set; }

        [Required]
        public string SocialSecurity { get; set; }

        public string DesiredSalary { get; set; }

        [Required]
        public string UsCitizen { get; set; }
        public string ExplainCitizen { get; set; }

        [Required]
        public string WorkedBefore { get; set; }
        public string ExplainWorkedBefore { get; set; }

        [Required]
        public string Felon { get; set; }
        public string ExplainFelon { get; set; }

        [Required]
        public string AuthorizedToWork { get; set; }
        public string ExplainWork { get; set; }
    }
}
