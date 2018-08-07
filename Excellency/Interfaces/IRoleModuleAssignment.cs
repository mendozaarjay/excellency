using Excellency.Models;
using System.Collections.Generic;

namespace Excellency.Interfaces
{
    public interface IRoleModuleAssignment
    {
        void Add(RoleModulesHeader Header, List<RoleModulesLine> LineItems);
        void Update(RoleModulesHeader Header, List<RoleModulesLine> LineItems);
        IEnumerable<RoleModulesHeader> RoleModules();
        IEnumerable<RoleModulesLine> GetLineItemsPerHeaderId(int id);
        RoleModulesHeader GetRoleModulesHeaderById(int id);

        IEnumerable<Role> Roles();
        IEnumerable<Module> Modules();
        void RemoveById(int Id);
        void RemoveLineById(int Id);
    }
}
