namespace iDent.API.Services
{
    public interface ICodeGeneratorService
    {
        Task<string> GenerateVerificationCode();
    }
}