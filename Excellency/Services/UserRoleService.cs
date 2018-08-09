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
    public class UserRoleService : IUserRole
    {
        private EASDbContext _dbContext;

        public UserRoleService(EASDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Account> Accounts()
        {
            return _dbContext.Accounts.Where(a => a.IsDeactivated == false && a.IsDeleted == false);
        }

        public void Add(UserRoleHeader Header, List<UserRoleLine> LineItems)
        {
            _dbContext.UserRoleHeader.Add(Header);
            foreach(var item in LineItems)
            {
                item.RoleHeader = Header;
                _dbContext.Add(item);
            }
            _dbContext.SaveChanges();
        }

        public IEnumerable<UserRoleLine> GetLineItemsPerHeaderId(int id)
        {
            return _dbContext.UserRoleLine
                .Include(a => a.RoleHeader)
                .Where(a => a.RoleHeader.Id == id && a.IsDeleted == false);
        }

        public UserRoleHeader GetUserRoleHeaderById(int id)
        {
            return _dbContext.UserRoleHeader.FirstOrDefault(a => a.Id == id);
        }

        public void RemoveById(int Id)
        {
            var header = _dbContext.UserRoleHeader.FirstOrDefault(a => a.Id == Id);
            header.IsDeleted = true;
            _dbContext.Entry(header).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void RemoveLineById(int Id)
        {
            var line = _dbContext.UserRoleLine.FirstOrDefault(a => a.Id == Id);
            line.IsDeleted = true;
            _dbContext.Entry(line).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public IEnumerable<Role> Roles()
        {
            return _dbContext.Roles.Where(a => a.IsDeleted == false);
        }

        public void Update(UserRoleHeader Header, List<UserRoleLine> LineItems)
        {
            _dbContext.Entry(Header).State = EntityState.Modified;
            foreach(var item in LineItems)
            {
                _dbContext.Entry(item).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }

        public IEnumerable<UserRoleHeader> UserRoles()
        {
            return _dbContext.UserRoleHeader.Where(a => a.IsDeleted == false);
        }
    }
}
