using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Repositories
{
    public interface IPlatformerUserRepository
    {
        Task<IEnumerable<PlatformerUser>> GetAllAsync(
            bool orderAscendant,
            string search = null);
        Task<PlatformerUser> GetByIdAsync(int id);
        Task<PlatformerUser> CreateAsync(PlatformerUser user);
        Task<PlatformerUser> EditAsync(PlatformerUser user);
        Task DeleteAsync(int id);
        Task<PlatformerUser> GetCpfAsync(string cpf, int id);
    }
}
