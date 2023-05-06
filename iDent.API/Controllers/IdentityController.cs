using iDent.API.Models.Repository.IRepository;
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
	}
}