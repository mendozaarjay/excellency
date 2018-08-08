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
    public class AccountService : IAccount
    {
        private EASDbContext _dbContext;

        public AccountService(EASDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Account> Accounts()
        {
            return _dbContext.Accounts.Where(a => a.IsDeleted == false && a.IsDeactivated == false);
        }

        public void Add(Account Account)
        {
            _dbContext.Accounts.Add(Account);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Branch> Branches()
        {
            return _dbContext.Branches.Where(a => a.IsDeleted == false);
        }

        public IEnumerable<Company> Companies()
        {
            return _dbContext.Companies.Where(a => a.IsDeleted == false);
        }

        public IEnumerable<Department> Departments()
        {
            return _dbContext.Departments.Where(a => a.IsDeleted == false);
        }

        public Account GetAccountById(int id)
        {
            return _dbContext.Accounts
                   .Include(a => a.Company)
                   .Include(a => a.Branch)
                   .Include(a => a.Department)
                   .Include(a => a.Position)
                   .FirstOrDefault(a => a.Id == id);
        }

        public Branch GetBranchById(int id)
        {
            return _dbContext.Branches.FirstOrDefault(a => a.Id == id);
        }

        public Company GetCompanyById(int id)
        {
            return _dbContext.Companies.FirstOrDefault(a => a.Id == id);
        }

        public Department GetDepartmentById(int id)
        {
            return _dbContext.Departments.FirstOrDefault(a => a.Id == id);
        }

        public Position GetPositionById(int id)
        {
            return _dbContext.Positions.FirstOrDefault(a => a.Id == id);
        }

        public bool IsAccountLocked(Account account)
        {
            return _dbContext.Accounts.Any(a => a.Id == account.Id && a.IsLocked == true);
        }

        public bool IsAvailableToLogin(Account account)
        {
            return _dbContext.Accounts.Any(a => a.Username == account.Username && a.Password == account.Password);
        }

        public bool IsLoginExpired(Account account)
        {
            throw new NotImplementedException();
        }

        public bool IsUserAlreadyExist(Account account)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Position> Positions()
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Account Account)
        {
            throw new NotImplementedException();
        }
    }
}
