using iDent.API.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace iDent.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InvitationsController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork;

        public InvitationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("identity/{identityId}")]
        public async Task<IActionResult> GetByIdentity(int identityId) => Ok(await _unitOfWork.Invitation.GetByIdentityIdAsync(identityId));

        [HttpGet("bank/{bankId}")]
        public async Task<IActionResult> GetByBank(int bankId) => Ok(await _unitOfWork.Invitation.GetByBankIdAsync(bankId));

    }
}