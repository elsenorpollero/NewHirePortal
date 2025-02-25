﻿using System;
using System.ComponentModel.DataAnnotations;

namespace NewHirePortalClean.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool IsApplicationComplete { get; set; }  // Example flag

        public DateTime LastUpdated { get; set; }  // Example additional property
    }
}
