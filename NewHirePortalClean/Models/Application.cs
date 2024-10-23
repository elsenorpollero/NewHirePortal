using System;
using System.ComponentModel.DataAnnotations;

namespace NewHirePortalClean.Models
{
    public class Application
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string EmployeeName { get; set; } = string.Empty;

        // Add the UserName property
        public string UserName { get; set; }

        // This is already in place, but I'll leave it here as part of the update.
        public bool IsGuest { get; set; }

        public DateTime LastUpdated { get; set; }

        public bool IsComplete { get; set; }
    }
}
