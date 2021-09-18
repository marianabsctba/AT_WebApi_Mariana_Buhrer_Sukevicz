using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Domain.Model.Models;

namespace Domain.Model.Interfaces.Services
{
    public interface IPlatformerUserService
    {
        Task<IEnumerable<PlatformerUser>> GetAllAsync(
            bool orderAscendant,
            string search = null);
        Task<PlatformerUser> GetByIdAsync(int id);
        Task<PlatformerUser> CreateAsync(PlatformerUser user);
        Task<PlatformerUser> EditAsync(PlatformerUser user);
        Task DeleteAsync(int id);
        Task<bool> IsCpfValidAsync(string cpf, int id);
    }
}
