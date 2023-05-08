using iDent.API.Models.Repository.IRepository;
using iDent.ModelLibrary.Models.Data;
using iDent.ModelLibrary.Models.Local;
using Microsoft.AspNetCore.Mvc;

namespace iDent.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public IdentityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Post(IdentityRequest request)
        {
            var result = await _unitOfWork.Identity.AddAsync(new Identity
            {
                Address = request.Address,
                DOB = request.DOB,
                FirstNames = request.FirstNames,
                Email = request.Email,
                IdentityNumber = request.IdentityNumber,
                LastName = request.LastName,
                MobileNumber = request.MobileNumber
            });
            
            _unitOfWork.SaveChanges();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateIdentityRequest request)
        {
            var result = await _unitOfWork.Identity.UpdateAsync(new Identity
            {
                Id = request.Id,
                Address = request.Address,
                DOB = request.DOB,
                FirstNames = request.FirstNames,
                Email = request.Email,
                IdentityNumber = request.IdentityNumber,
                LastName = request.LastName,
                MobileNumber = request.MobileNumber
            });

            _unitOfWork.SaveChanges();

            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _unitOfWork.Identity.FindAsync(id);
            if (!result.Success) return NotFound(result);

            return Ok(result);
        }
    }
}