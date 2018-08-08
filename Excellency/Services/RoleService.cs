using Excellency.Interfaces;
using Excellency.Models;
using Excellency.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excellency.Services
{
    public class RoleService : IRole
    {
        private EASDbContext _dbContext;

        public RoleService(EASDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Role Role)
        {
            _dbContext.Add(Role);
            _dbContext.SaveChanges();
        }

        public Role GetRoleById(int id)
        {
            return _dbContext.Roles.FirstOrDefault(a => a.Id == id);
        }

        public void RemoveById(int Id)
        {
            var Role = _dbContext.Roles.FirstOrDefault(a => a.Id == Id);
            Role.IsDeleted = true;
            _dbContext.Entry(Role).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public IEnumerable<Role> Roles()
        {
            return _dbContext.Roles.Where(a => a.IsDeleted == false);
        }

        public void Update(Role Role)
        {
            _dbContext.Entry(Role).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
