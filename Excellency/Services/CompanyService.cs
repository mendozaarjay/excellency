using System.Collections.Generic;
using System.Linq;
using Excellency.Interfaces;
using Excellency.Models;
using Excellency.Persistence;

namespace Excellency.Services
{
    public class CompanyService : ICompany
    {
        private EASDbContext _dbContext;

        public CompanyService(EASDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Company company)
        {
            _dbContext.Add(company);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Company> Companies()
        {
            return _dbContext.Companies;
        }

        public Company GetCompanyById(int id)
        {
            return _dbContext.Companies.FirstOrDefault(x => x.Id == id);
        }

        public string GetCompanyLogoUrlById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Company company)
        {
            throw new System.NotImplementedException();
        }
    }
}
