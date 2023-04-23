using iDent.ModelLibrary.Models.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace iDent.API.Services
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration) => _configuration = configuration;
        
        public Task<string> GenerateTokenAsync(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtService:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("UserId", account.Id.ToString()),
                    new Claim(ClaimTypes.Email, account.Email!)
                }),

                Expires = DateTime.Now.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            account.Token = tokenHandler.WriteToken(token);

            return Task.FromResult(account.Token);
        }
    }
}