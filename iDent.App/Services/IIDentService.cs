using iDent.ModelLibrary.Models.Data;
using iDent.ModelLibrary.Models.Local;

namespace iDent.App.Services
{
    public interface IIDentService
    {
        Task<Result<Identity>> AddIdentityAsync(IdentityRequest request);
    }
}