using iDent.ModelLibrary.Models.Data;

namespace iDent.API.Services
{
    public interface IJwtService
    {
        Task<string> GenerateTokenAsync(Account account);
    }
}