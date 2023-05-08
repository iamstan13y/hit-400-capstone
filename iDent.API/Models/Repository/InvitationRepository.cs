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

        public async new Task<Result<Invitation>> FindAsync(int identityId)
        {
            var invitation = await _dbSet
                .Where(x => x.IdentityId == identityId)
                .Include(x => x.Bank)
                .Include(x => x.Identity)
                .FirstOrDefaultAsync();

            if (invitation == null) return new Result<Invitation>(false, "Invitation not found.");

            return new Result<Invitation>(invitation);
        }
    }
}