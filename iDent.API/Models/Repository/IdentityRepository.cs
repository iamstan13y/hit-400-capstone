using iDent.API.Models.Data;
using iDent.API.Models.Repository.IRepository;
using iDent.ModelLibrary.Models.Data;

namespace iDent.API.Models.Repository
{
	public class IdentityRepository : Repository<Identity>, IIdentityRepository
	{
		public IdentityRepository(AppDbContext context) : base(context)
		{
		}
	}
}