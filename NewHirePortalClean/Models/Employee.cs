using System;

namespace NewHirePortalClean.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsApplicationComplete { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
