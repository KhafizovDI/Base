﻿using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace PromoCodeFactory.WebHost.Controllers
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public  async Task CreateEmployee(string firstName, string lastName, string email)
        {
            Employee employee = new Employee()
            {
                Id = Guid.NewGuid(),
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                Roles = new List<Role>(),
                AppliedPromocodesCount = 0
            };
            await _employeeRepository.AddAsync(employee);
        }
  
        public async Task UpdateEmployee(Guid id, string firstName, string lastName, string email)
        {
            Employee employee = new Employee()
            {
                Id = id,
                Email = email,
                FirstName = firstName,
                LastName = lastName
            };
            await _employeeRepository.UpdateAsync(employee);
        }
    }
}