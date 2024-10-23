using System;
using System.ComponentModel.DataAnnotations;

namespace NewHirePortalClean.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public DateTime LastLogin { get; set; }
    }
}
