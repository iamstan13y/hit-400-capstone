using iDent.API.Models.Repository.IRepository;
using iDent.ModelLibrary.Models.Local;
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

        [HttpPost("request")]
        public async Task<IActionResult> SendRequest(InvitationRequest request)
        {
            var result = await _unitOfWork.Invitation.SendRequestAsync(request);

            _unitOfWork.SaveChanges();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("request/review")]
        public async Task<IActionResult> ReviewRequest(ReviewInvitationRequest request)
        {
            var result = await _unitOfWork.Invitation.ReviewRequestAsync(request);

            _unitOfWork.SaveChanges();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }
    }
}