using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;

namespace OdontoPrev.Infrastructure.Services
{
    public class FotoValidationService
    {
        private readonly HttpClient _httpClient;

        public FotoValidationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> ValidarFotoAsync(string urlFoto)
        {
            // Implementar chamada para API externa de validação de imagens
            var response = await _httpClient.GetAsync($"api/validate?imageUrl={urlFoto}");
            if (response.IsSuccessStatusCode)
            {
                var resultado = await response.Content.ReadAsStringAsync();
                return bool.Parse(resultado); // Supondo que a API retorna um boolean
            }
            return false;
        }
    }
}

