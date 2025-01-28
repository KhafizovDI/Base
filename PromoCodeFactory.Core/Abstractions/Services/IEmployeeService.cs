﻿using System;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Abstractions.Repositories
{
    public interface IEmployeeService
    {
        Task CreateEmployee(string firstName, string lastName, string email, string role, int promocodeCount);
        Task UpdateEmployee(Guid id, string firstName, string lastName, string email, string role, int promocodeCount);
    }
}