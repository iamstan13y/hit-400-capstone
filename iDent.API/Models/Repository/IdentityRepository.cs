using iDent.API.Models.Data;
using iDent.API.Models.Repository.IRepository;
using iDent.ModelLibrary.Models.Data;
using iDent.ModelLibrary.Models.Local;
using Microsoft.EntityFrameworkCore;

namespace iDent.API.Models.Repository
{
	public class IdentityRepository : Repository<Identity>, IIdentityRepository
	{
		public IdentityRepository(AppDbContext context) : base(context)
		{
		}

        public async Task<Result<Identity>> AuthenticateAsync(LoginRequest request)
        {
			var identity = await _dbSet.Where(x => x.Email == request.Email).FirstOrDefaultAsync();
			if (identity == null) return new Result<Identity>(false, "Username or Password is incorrect.");

			return new Result<Identity>(identity);
        }
    }
}