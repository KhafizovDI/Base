using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace PromoCodeFactory.WebHost.Controllers
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRoleRepository<Role> _roleRepository;

        public EmployeeService(IRepository<Employee> employeeRepository, IRoleRepository<Role> roleRepository)
        {
            _employeeRepository = employeeRepository;
            _roleRepository = roleRepository;

        }

        public  async Task CreateEmployee(string firstName, string lastName, string email, string role, int promocodeCount)
        {
            Employee employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Roles = new List<Role>() 
                {
                    await _roleRepository.GetByNameAsync(role)
                },
                AppliedPromocodesCount = promocodeCount
            };
            await _employeeRepository.AddAsync(employee);
        }

        public async Task UpdateEmployee(Guid id, string firstName, string lastName, string email, string role, int promocodeCount)
        {
            Employee employee = new Employee()
            {
                Id = id,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Roles = new List<Role>()
                {
                    await _roleRepository.GetByNameAsync(role)
                },
                AppliedPromocodesCount = promocodeCount
            };
            await _employeeRepository.UpdateAsync(employee);
        }

    }
}