using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BloodBank.Application.Models.Doador;

namespace BloodBank.Infrastructure.Services
{
    public class ViaCepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ViaCepResponseModel?> BuscarEnderecoPorCep(string cep)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ViaCepResponseModel>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}