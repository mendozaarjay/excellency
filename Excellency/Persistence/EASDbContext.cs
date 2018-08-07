using Excellency.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excellency.Persistence
{
    public class EASDbContext : DbContext
    {
        public EASDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleModulesHeader> RoleModulesHeader { get; set; }
        public DbSet<RoleModulesLine> RoleModulesLine { get; set; }
        public DbSet<UserRoleHeader> UserRoleHeader { get; set; }
        public DbSet<UserRoleLine> UserRoleLine { get; set; }

    }
}
