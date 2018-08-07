using Excellency.Models;
using System.Collections.Generic;

namespace Excellency.Interfaces
{
    public interface IRole
    {
        void Add(Role Role);
        void Update(Role Role);
        IEnumerable<Role> Roles();
        Role GetRoleById(int id);
        void RemoveById(int Id);
    }
}
