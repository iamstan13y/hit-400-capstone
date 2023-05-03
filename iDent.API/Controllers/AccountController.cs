using iDent.API.Models.Repository.IRepository;
using iDent.ModelLibrary.Models.Local;
using Microsoft.AspNetCore.Mvc;

namespace iDent.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository) => _accountRepository = accountRepository;

        [HttpPost]
        public async Task<IActionResult> Post(AccountRequest request)
        {
            var result = await _accountRepository.AddAsync(request);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post(LoginRequest request)
        {
            var result = await _accountRepository.LoginAsync(request);
            if (!result.Success) return Unauthorized(result);

            return Ok(result);
        }
    }
}