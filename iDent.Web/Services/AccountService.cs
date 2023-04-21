using iDent.ModelLibrary.Models.Data;
using iDent.ModelLibrary.Models.Local;
using iDent.Web.Services.IServices;

namespace iDent.Web.Services
{
    public class AccountService : IAccountService
    {
        public Task<Result<Account>> AddAsync(Account account)
        {
            throw new NotImplementedException();
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