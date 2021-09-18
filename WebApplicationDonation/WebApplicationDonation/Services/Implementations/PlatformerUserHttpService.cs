using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplicationDonation.Models;

namespace WebApplicationDonation.Services.Implementations
{
    public class PlatformerUserHttpService : IPlatformerUserHttpService
    {
        private readonly HttpClient _httpClient;

        private static readonly JsonSerializerOptions JsonSerializerOptions = new()
        {
            IgnoreNullValues = true,
            PropertyNameCaseInsensitive = true
        };

        public PlatformerUserHttpService(
            HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PlatformerUserViewModel> CreateAsync(PlatformerUserViewModel userViewModel)
        {
            var httpResponseMessage = await _httpClient
                .PostAsJsonAsync(string.Empty, userViewModel);

            await using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var userCreated = await JsonSerializer
                .DeserializeAsync<PlatformerUserViewModel>(contentStream, JsonSerializerOptions);

            return userCreated;
        }

        public async Task DeleteAsync(int id)
        {
            var httpResponseMessage = await _httpClient
                .DeleteAsync($"{id}");

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task<PlatformerUserViewModel> EditAsync(PlatformerUserViewModel userViewModel)
        {
            var httpResponseMessage = await _httpClient
                .PutAsJsonAsync($"{userViewModel.Id}", userViewModel);

            httpResponseMessage.EnsureSuccessStatusCode();

            await using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            var userEdited = await JsonSerializer
                .DeserializeAsync<PlatformerUserViewModel>(contentStream, JsonSerializerOptions);

            return userEdited;
        }

        public async Task<IEnumerable<PlatformerUserViewModel>> GetAllAsync(bool orderAscendant, string search = null)
        {
            var users = await _httpClient
                .GetFromJsonAsync<IEnumerable<PlatformerUserViewModel>>($"{orderAscendant}/{search}");

            return users;
        }

        public async Task<PlatformerUserViewModel> GetByIdAsync(int id)
        {
            var users = await _httpClient
                .GetFromJsonAsync<PlatformerUserViewModel>($"{id}");

            return users;
        }

        public async Task<bool> IsCpfValidAsync(string cpf, int id)
        {
            var isCpfValid = await _httpClient
                .GetFromJsonAsync<bool>($"IsCpfValid/{cpf}/{id}");

            return isCpfValid;
        }
    }
}



