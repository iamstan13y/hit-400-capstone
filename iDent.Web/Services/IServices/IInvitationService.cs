using iDent.ModelLibrary.Models.Data;
using iDent.ModelLibrary.Models.Local;

namespace iDent.Web.Services.IServices
{
    public interface IInvitationService
    {
        Task<Result<Invitation>> AddAsync(InvitationRequest request);
        Task<Result<IEnumerable<Invitation>>> GetByBankIdAsync(int bankId);
        //Task<Result<IEnumerable<Account>>> GetAllAsync();
        //Task<Result<Account>> UpdateAsync(Account account);
        //Task<Result<bool>> DeleteAsync(Account account);
    }
}