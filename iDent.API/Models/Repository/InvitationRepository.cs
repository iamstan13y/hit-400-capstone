using iDent.API.Models.Data;
using iDent.API.Models.Repository.IRepository;
using iDent.ModelLibrary.Models.Data;
using iDent.ModelLibrary.Models.Local;
using iDent.ModelLibrary.Utility;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace iDent.API.Models.Repository
{
    public class InvitationRepository : Repository<Invitation>, IInvitationRepository
    {
        public InvitationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Result<IEnumerable<Invitation>>> GetByIdentityIdAsync(int identityId)
        {
            var invitations = await _dbSet
                .Where(x => x.IdentityId == identityId)
                .Include(x => x.Bank)
                .Include(x => x.Identity)
                .ToListAsync();

            return new Result<IEnumerable<Invitation>>(invitations);
        }

        public async Task<Result<IEnumerable<Invitation>>> GetByBankIdAsync(int bankId)
        {
            var invitations = await _dbSet
                .Where(x => x.BankId == bankId)
                .Include(x => x.Bank)
                .Include(x => x.Identity)
                .ToListAsync();

            return new Result<IEnumerable<Invitation>>(invitations);
        }

        public async Task<Result<Invitation>> SendRequestAsync(InvitationRequest request)
        {
            var invitation = new Invitation
            {
                BankId = request.BankId,
                IdentityId = request.IdentityId,
                Reason = request.Reason
            };

            await _dbSet.AddAsync(invitation);

            return new Result<Invitation>(invitation);
        }

        public async Task<Result<Invitation>> ReviewRequestAsync(ReviewInvitationRequest request)
        {
            var invitation = await _dbSet.FindAsync(request.InvitationId);

            if (invitation == null) return new Result<Invitation>(false, "Invitation not found.");

            invitation.Status = request.Status;
            invitation.DateUpdated = DateTime.Now;

            _dbSet.Update(invitation);
            
            return new Result<Invitation>(invitation);
        }
    }
}