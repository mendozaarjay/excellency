using System;

namespace Excellency.Models
{
    public class UserRoleLine
    {
        public int Id { get; set; }
        public Role Role { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsDeleted { get; set; } = false;

    }

}
