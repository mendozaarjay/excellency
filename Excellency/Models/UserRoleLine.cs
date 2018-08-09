using System;

namespace Excellency.Models
{
    public class UserRoleLine
    {
        public int Id { get; set; }
        public virtual Role Role { get; set; }
        public virtual UserRoleHeader RoleHeader { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsDeleted { get; set; } = false;

    }

}
