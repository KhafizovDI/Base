using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Abstractions.Repositories
{
    public interface IRoleRepository<Role>    
    {
        Task<Role> GetByNameAsync(string name);
    }
}