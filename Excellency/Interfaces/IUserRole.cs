using Excellency.Models;
using System.Collections.Generic;

namespace Excellency.Interfaces
{
    public interface IUserRole
    {
        void Add(UserRoleHeader Header, List<UserRoleLine> LineItems);
        void Update(UserRoleHeader Header, List<UserRoleLine> LineItems);
        IEnumerable<UserRoleHeader> UserRoles();
        IEnumerable<UserRoleLine> GetLineItemsPerHeaderId(int id);
        UserRoleHeader GetUserRoleHeaderById(int id);

        IEnumerable<Role> Roles();
        IEnumerable<Account> Accounts();
        void RemoveById(int Id);
        void RemoveLineById(int Id);
    }
}
