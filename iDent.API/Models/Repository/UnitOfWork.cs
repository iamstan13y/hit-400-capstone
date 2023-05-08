using iDent.API.Models.Data;
using iDent.API.Models.Repository.IRepository;

namespace iDent.API.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

		public IIdentityRepository Identity { get; private set; }
        public IInvitationRepository Invitation { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Identity = new IdentityRepository(context);
            Invitation = new InvitationRepository(context);
        }
        
        public void SaveChanges() => _context.SaveChanges();
    }
}