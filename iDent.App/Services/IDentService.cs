using iDent.ModelLibrary.Extensions;
using iDent.ModelLibrary.Models.Data;
using iDent.ModelLibrary.Models.Local;
using System.Net.Http.Json;

namespace iDent.App.Services
{
    public class IDentService : IIDentService
    {

        private readonly HttpClient _httpClient;

        public IDentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<Identity>> AddIdentityAsync(IdentityRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/v1/Identity", request);
            if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when calling API.");

            return await response.ReadContentAsAsync<Result<Identity>>();
        }
    }
}