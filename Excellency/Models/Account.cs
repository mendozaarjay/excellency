using System;
using System.ComponentModel.DataAnnotations;

namespace Excellency.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Mobile { get; set; }
        [Required]
        [MaxLength(255)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool IsVerified { get; set; } = true;
        public bool IsLocked { get; set; } = false;
        public bool IsDeactivated { get; set; } = false;
        public bool IsChangedPassword { get; set; } = false;

        public Company Company { get; set; }
        public Branch Branch { get; set; }
        public Department Department { get; set; }
        public Position Position { get; set; }

        //This columns are important for auditing
        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
