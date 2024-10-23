using System;
using System.ComponentModel.DataAnnotations;

namespace NewHirePortalClean.Models
{
    public class EmployeeApplication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }  // Employee Identifier

        [Required]
        public string Status { get; set; } = string.Empty;  // Application status

        [Required]
        public string FirstName { get; set; } = string.Empty;  // Employee's first name

        [Required]
        public string LastName { get; set; } = string.Empty;  // Employee's last name

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;  // Employee's email address

        public bool IsComplete { get; set; }  // Indicates if the application is complete

        public DateTime ApplicationDate { get; set; } = DateTime.Now;  // Date the application was submitted

        public DateTime LastUpdated { get; set; } = DateTime.Now;  // Date the application was last updated

        public string EmployeeName => FirstName + " " + LastName;  // Full name for convenience
    }
}