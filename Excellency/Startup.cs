using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excellency.Interfaces;
using Excellency.Persistence;
using Excellency.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Excellency
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(Configuration);
            services.AddScoped<ICompany, CompanyService>();
            services.AddScoped<IBranch, BranchService>();
            services.AddScoped<IDepartment, DepartmentService>();
            services.AddScoped<IPosition, PositionService>();
            services.AddScoped<IRole, RoleService>();
            services.AddScoped<IModule, ModuleService>();
            services.AddScoped<IAccount, AccountService>();
            services.AddScoped<IEmployee, EmployeeService>();
            services.AddScoped<IRoleModuleAssignment, RoleModuleService>();
            services.AddScoped<IUserRole, UserRoleService>();

            services.AddDbContext<EASDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ExcellencyConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
