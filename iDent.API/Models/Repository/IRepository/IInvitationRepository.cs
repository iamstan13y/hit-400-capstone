using iDent.ModelLibrary.Models.Data;
using iDent.ModelLibrary.Models.Local;

namespace iDent.API.Models.Repository.IRepository
{
    public interface IInvitationRepository : IRepository<Invitation>
    {
        Task<Result<IEnumerable<Invitation>>> GetByIdentityIdAsync(int identityId);
        Task<Result<IEnumerable<Invitation>>> GetByBankIdAsync(int bankId);
        Task<Result<Invitation>> SendRequestAsync(InvitationRequest request);
        Task<Result<Invitation>> ReviewRequestAsync(ReviewInvitationRequest request);
    }
}