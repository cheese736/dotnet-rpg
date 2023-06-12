using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg.Controllers
{

	[ApiController]
	[Route("[controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthRepository _authRepo;

		public AuthController(IAuthRepository authRepo)
		{
			_authRepo = authRepo;
		}
		[HttpPost("Register")]
		public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
		{
			var response = await _authRepo.Register(
					new User { Username = request.UserName }, request.Password
			);

			return response.Success ? Ok(response) : BadRequest(response);

		}
	}
}