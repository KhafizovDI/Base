using PromoCodeFactory.Core.Domain.Administration;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Abstractions.Repositories
{
    public interface IRoleRepository
    {
        Task<Role> GetByName(string name);
    }
}