using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.DataAccess.Data;
using PromoCodeFactory.DataAccess.Repositories;
using PromoCodeFactory.WebHost.Controllers;

namespace PromoCodeFactory.WebHost
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<IRepository<Employee>>((x) =>
                new Repository<Employee>(FakeDataFactory.Employees));
            
            services.AddSingleton<IRepository<Role>>((x) =>
                new Repository<Role>(FakeDataFactory.Roles));

            services.AddSingleton<IRoleRepository<Role>>((x) => new RoleRepository(FakeDataFactory.Roles));

            services.AddSingleton<IEmployeeService, EmployeeService>();


            services.AddOpenApiDocument(options =>
            {
                options.Title = "PromoCode Factory API Doc";
                options.Version = "1.0";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseOpenApi();
            app.UseSwaggerUi(x =>
            {
                x.DocExpansion = "list";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}