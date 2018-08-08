namespace Excellency.Models
{
    public class RoleModulesLine
    {
        public int Id { get; set; }

        public virtual RoleModulesHeader RoleModulesHeader { get; set; }
        public virtual Module Module { get; set; }

        public bool New { get; set; } = true;
        public bool Save { get; set; } = true;
        public bool Delete { get; set; } = true;
        public bool Search { get; set; } = true;
        public bool Print { get; set; } = true;
        public bool Post { get; set; } = true;
        public bool Import { get; set; } = true;
        public bool Export { get; set; } = true;
        public bool Approve { get; set; } = true;

        public bool IsDeleted { get; set; } = false;

    }
}
