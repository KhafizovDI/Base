using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain;
using PromoCodeFactory.Core.Domain.Administration;
namespace PromoCodeFactory.DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository<Role>
    {    
        protected IEnumerable<Role> Roles;

        public RoleRepository(IEnumerable<Role> rolesRepository)
        {
            Roles = rolesRepository;
        }

        public Task<Role> GetByNameAsync(string name)
        {
            return Task.FromResult(Roles.FirstOrDefault(x => x.Name == name));
        }
    }
}