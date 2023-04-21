using iDent.ModelLibrary.Models.Data;
using iDent.ModelLibrary.Models.Local;

namespace iDent.Web.Services.IServices
{
    public interface IAccountService
    {
        Task<Result<Account>> AddAsync(AccountRequest request);
        Task<Result<Account>> GetByIdAsync(int id);
        Task<Result<IEnumerable<Account>>> GetAllAsync();
        Task<Result<Account>> UpdateAsync(Account account);
        Task<Result<bool>> DeleteAsync(Account account);
        Task<Result<Account>> LoginAsync(LoginRequest login);
        //Task<Result<Account>> ChangePasswordAsync(ChangePasswordRequest changePassword);
        Task<Result<string>> GetResetPasswordCodeAsync(string email);
        // Task<Result<Account>> ResetPasswordAsync(ResetPasswordRequest resetPassword);
        //Task<Result<Account>> ConfirmAccountAsync(ConfirmAccountRequest confirmAccount);
        Task<Result<string>> ResendOtpAsync(string email);
    }
}