﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Excellency.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string EmployeeNo { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string MiddleName { get; set; }

        public Company Company { get; set; }
        public Branch Branch { get; set; }
        public Department Department { get; set; }
        public Position Position { get; set; }
       

        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
