using System;

namespace Excellency.Models
{
    public class UserRoleHeader
    {
        public int Id { get; set; }
        public Account Account { get; set; }

        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
