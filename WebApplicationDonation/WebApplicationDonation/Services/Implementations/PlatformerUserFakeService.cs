using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplicationDonation.Models;

namespace WebApplicationDonation.Services.Implementations
{
    public class PlatformerUserFakeService : IPlatformerUserHttpService
    {
        private static List<PlatformerUserViewModel> Users { get; } = new List<PlatformerUserViewModel>
        {
            new PlatformerUserViewModel
            {
                Id = 0,
                UserName = "Mariana",
                UserLastName = "Buhrer",
                DateOfRegister = new DateTime(2021, 02, 23),
                UserBirthday = new DateTime(1988, 02, 23),
                UserLegalStatus = true,
                UserAddress = "Mafalda222",
                UserAddressDetails = "Parana",
                Cpf = "07215853966",
                UserTimeInDonation = 1,
                QuantityDonations = 0

            },
            new PlatformerUserViewModel
            {
                Id = 1,
                UserName = "Jack",
                UserLastName = "Bauer",
                DateOfRegister = new DateTime(2022, 02, 23),
                UserBirthday = new DateTime(1988, 02, 25),
                UserLegalStatus = true,
                UserAddress = "Pinel",
                UserAddressDetails = "Parana",
                Cpf = "07215853966",
                UserTimeInDonation = 1,
                QuantityDonations = 3
            }
        };

        public async Task<IEnumerable<PlatformerUserViewModel>> GetAllAsync(bool orderAscendant, string search = null)
        {
            if (search == null)
            {
                return Users;
            }

            var resultByLinq = Users
                .Where(x =>
                    x.UserName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    x.UserLastName.Contains(search, StringComparison.OrdinalIgnoreCase));

            resultByLinq = orderAscendant
                ? resultByLinq.OrderBy(x => x.UserName).ThenBy(x => x.UserLastName)
                : resultByLinq.OrderByDescending(x => x.UserName).ThenByDescending(x => x.UserLastName);

            return resultByLinq;
        }

        public async Task<PlatformerUserViewModel> GetByIdAsync(int id)
        {
            foreach (var user in Users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }

            return null;
        }

        private static int _id = Users.Max(x => x.Id);
        private int Id => Interlocked.Increment(ref _id);

        public async Task<PlatformerUserViewModel> CreateAsync(PlatformerUserViewModel userViewModel)
        {
            userViewModel.Id = Id;

            Users.Add(userViewModel);

            return userViewModel;
        }

        public async Task<PlatformerUserViewModel> EditAsync(PlatformerUserViewModel userViewModel)
        {
            foreach (var user in Users)
            {
                if (user.Id == userViewModel.Id)
                {
                    user.UserName = userViewModel.UserName;
                    user.UserLastName = userViewModel.UserLastName;
                    user.DateOfRegister = userViewModel.DateOfRegister;
                    user.UserBirthday = userViewModel.UserBirthday;
                    user.UserLegalStatus = userViewModel.UserLegalStatus;
                    user.UserAddress = userViewModel.UserAddress;
                    user.UserAddressDetails = userViewModel.UserAddressDetails;
                    user.Cpf = userViewModel.Cpf;
                    user.UserTimeInDonation = userViewModel.UserTimeInDonation;
                    user.QuantityDonations = userViewModel.QuantityDonations;

                    return user;
                }
            }
            return null;
        }

        public async Task DeleteAsync(int id)
        {
            PlatformerUserViewModel foundedUser = null;
            foreach (var user in Users)
            {
                if (user.Id == id)
                {
                    foundedUser = user;
                }
            }

            if (foundedUser != null)
            {
                Users.Remove(foundedUser);
            }

        }

        public async Task<bool> IsCpfValidAsync(string cpf, int id)
        {
            throw new NotImplementedException();
        }
    }
}
