using iDent.ModelLibrary.Models.Data;
using iDent.ModelLibrary.Models.Local;

namespace iDent.API.Models.Repository.IRepository
{
	public interface IIdentityRepository : IRepository<Identity>
	{
		Task<Result<Identity>> AuthenticateAsync(LoginRequest request);
	}
}