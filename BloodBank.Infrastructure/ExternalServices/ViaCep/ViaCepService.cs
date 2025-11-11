using BloodBank.Application.Models;
using BloodBank.Application.Services;
using Newtonsoft.Json;

namespace BloodBank.Infrastructure.ExternalServices.ViaCep
{
    public class ViaCepService : IZipCodeService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ZipCodeResult> GetZipCode(string code)
        {
            var cep = code.Replace("-", "").Trim();

            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

            var json = await response.Content.ReadAsStringAsync(); 

            return JsonConvert.DeserializeObject<ZipCodeResult>(json);
        }
    }
}
