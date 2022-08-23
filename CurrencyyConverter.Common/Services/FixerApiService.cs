using CurrencyyConverter.Infrastructure.Dtos;
using CurrencyyConverter.Infrastructure.Interfaces;
using System.Text.Json;

namespace CurrencyyConverter.Infrastructure.Services
{
    public class FixerApiService : IFxRatesServiceClient
    {
        private readonly string _baseUrl = "https://api.apilayer.com";
        private readonly string _apiKey = "PMdCuWhK3tB9NzPOL1ZH3CID9HSAyeDQ";

        public async Task<double> GetLatestRateAsync(string baseCurrency, string toCurrency)
        {
            var httpClient = InitializeHttpClient();

            var url = $"fixer/latest?symbols={toCurrency}&base={baseCurrency}";

            using var response = await httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStreamAsync();

            var ratesDto = await JsonSerializer.DeserializeAsync<FixerLatestRatesResponseDto>(content, new JsonSerializerOptions(JsonSerializerDefaults.Web));

            return ratesDto?.Success == true ? Convert.ToDouble(ratesDto.Rates[toCurrency]) : 0;
        }

        private HttpClient InitializeHttpClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };

            client.DefaultRequestHeaders.Add("apiKey", _apiKey);

            return client;
        }
    }
}
