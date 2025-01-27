using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.Core.Domain.Administration;

namespace PromoCodeFactory.Core.Abstractions.Repositories
{
    public interface IEmployeeService
    {
        Task CreateEmployee(string firstName, string lastName, string email, string role, int promocodeCount);
        Task UpdateEmployee(Guid id, string firstName, string lastName, string email);
    }
}