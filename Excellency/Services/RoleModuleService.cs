using Excellency.Interfaces;
using Excellency.Models;
using Excellency.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excellency.Services
{
    public class RoleModuleService : IRoleModuleAssignment
    {
        private EASDbContext _dbContext;

        public RoleModuleService(EASDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(RoleModulesHeader Header, List<RoleModulesLine> LineItems)
        {

            _dbContext.RoleModulesHeader.Add(Header);
            foreach(var item in LineItems)
            {
                item.RoleModulesHeader = Header;
                _dbContext.RoleModulesLine.Add(item);
            }
            _dbContext.SaveChanges();
        }

        public IEnumerable<RoleModulesLine> GetLineItemsPerHeaderId(int id)
        {
            return _dbContext.RoleModulesLine.Where(a => a.RoleModulesHeader.Id == id && a.IsDeleted == false);
        }

        public Module GetModuleById(int Id)
        {
            return _dbContext.Modules.FirstOrDefault(a => a.Id == Id);
        }

        public Role GetRoleById(int Id)
        {
            return _dbContext.Roles.FirstOrDefault(a => a.Id == Id);
        }

        public RoleModulesHeader GetRoleModulesHeaderById(int id)
        {
            return _dbContext.RoleModulesHeader.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Module> Modules()
        {
            return _dbContext.Modules.Where(a => a.IsDeleted == false);
        }

        public void RemoveById(int Id)
        {
            var header = _dbContext.RoleModulesHeader.FirstOrDefault(a => a.Id == Id);
            header.IsDeleted = true;
            _dbContext.Entry(header).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void RemoveLineById(int Id)
        {
            var line = _dbContext.RoleModulesLine.FirstOrDefault(a => a.Id == Id);
            line.IsDeleted = true;
            _dbContext.Entry(line).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public IEnumerable<RoleModulesHeader> RoleModules()
        {
            return _dbContext.RoleModulesHeader.Where(a => a.IsDeleted == false);
        }

        public IEnumerable<Role> Roles()
        {
            return _dbContext.Roles.Where(a => a.IsDeleted == false);
        }

        public void Update(RoleModulesHeader Header, List<RoleModulesLine> LineItems)
        {
            _dbContext.Entry(Header).State = EntityState.Modified;
            foreach(var item in LineItems)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }
    }
}
