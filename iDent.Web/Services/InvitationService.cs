using iDent.ModelLibrary.Extensions;
using iDent.ModelLibrary.Models.Data;
using iDent.ModelLibrary.Models.Local;
using iDent.Web.Services.IServices;
using System.Net.Http;

namespace iDent.Web.Services
{
    public class InvitationService : IInvitationService
    {
        private readonly HttpClient _httpClient;

        public InvitationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<Invitation>> AddAsync(InvitationRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/Invitations/request", request);
            if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when calling API.");

            return await response.ReadContentAsAsync<Result<Invitation>>();
        }

        public async Task<Result<IEnumerable<Invitation>>> GetByBankIdAsync(int bankId)
        {
            var response = await _httpClient.GetAsync($"api/v1/Invitations/bank/{bankId}");
            if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when calling API.");

            return await response.ReadContentAsAsync<Result<IEnumerable<Invitation>>>();
        }
    }
}