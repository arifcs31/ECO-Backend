using Microsoft.Net.Http.Headers;
using Shopex.Application.Interfaces;
using Shopex.Domain.Configurations;
using Shopex.Domain.Dto;
using System.Text.Json;

namespace Shopex.Infrastructure.Integration
{
    public class FindAddressPartyService : IFindAddressPartyService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly FindAddressConfiguration _findAddressConfiguration;
        public FindAddressPartyService(IHttpClientFactory httpClientFactory,
            FindAddressConfiguration findAddressConfiguration)
        {
            _findAddressConfiguration = findAddressConfiguration;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<AddressResult> FindAddress(string address, string postCode)
        {
            var httpRequestMessage = new HttpRequestMessage(
           //HttpMethod.Get,
           //$"{_findAddressConfiguration.URL}/{address}/{postCode}")
           // {
           //     Headers =
           // {
           //     { "x-api-key", _findAddressConfiguration.APIKey },
           //     { "referer", _findAddressConfiguration.Referer }
           // }
           // };

            HttpMethod.Get,
           $"{_findAddressConfiguration.URL}/{address}/{postCode}?api_key={_findAddressConfiguration.APIKey}")
            {
                Headers =
            {
                    { "x-api-key", _findAddressConfiguration.APIKey },
                { "referer", _findAddressConfiguration.Referer }
                }
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

               var addressResult = await JsonSerializer.DeserializeAsync
                    <AddressResult>(contentStream);
                return addressResult;
            }
            throw new InvalidDataException(httpResponseMessage?.StatusCode.ToString());
        }
    }
}
