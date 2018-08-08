using System;

namespace Excellency.Models
{
    public class RoleModulesHeader
    {
        public int Id { get; set; }
        
        public virtual Role Role { get; set; }

        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
