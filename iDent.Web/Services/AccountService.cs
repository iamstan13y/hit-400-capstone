using iDent.ModelLibrary.Extensions;
using iDent.ModelLibrary.Models.Data;
using iDent.ModelLibrary.Models.Local;
using iDent.Web.Services.IServices;

namespace iDent.Web.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;

        public AccountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<Account>> AddAsync(AccountRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync($"api/v1/Account", request);
            if (!response.IsSuccessStatusCode) throw new Exception("Something went wrong when calling API.");

            return await response.ReadContentAsAsync<Result<Account>>();
        }

        public Task<Result<bool>> DeleteAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<Account>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Account>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> GetResetPasswordCodeAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Account>> LoginAsync(LoginRequest login)
        {
            throw new NotImplementedException();
        }

        public Task<Result<string>> ResendOtpAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Account>> UpdateAsync(Account account)
        {
            throw new NotImplementedException();
        }
    }
}