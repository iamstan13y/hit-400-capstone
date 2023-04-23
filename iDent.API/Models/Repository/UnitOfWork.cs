using iDent.API.Models.Data;
using iDent.API.Models.Repository.IRepository;

namespace iDent.API.Models.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void SaveChanges() => _context.SaveChanges();
    }
}