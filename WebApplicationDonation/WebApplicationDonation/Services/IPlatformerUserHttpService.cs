using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationDonation.Models;

namespace WebApplicationDonation.Services
{
    public interface IPlatformerUserHttpService
    {
        Task<IEnumerable<PlatformerUserViewModel>> GetAllAsync(
            bool orderAscendant,
            string search = null);
        Task<PlatformerUserViewModel> GetByIdAsync(int id);
        Task<PlatformerUserViewModel> CreateAsync(PlatformerUserViewModel userViewModel);
        Task<PlatformerUserViewModel> EditAsync(PlatformerUserViewModel userViewModel);
        Task DeleteAsync(int id);
        Task<bool> IsCpfValidAsync(string cpf, int id);
    }
}
