using ASPLearning.Common;
using ASPLearning.Services.UserAccount;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace ASPLearning.Api.Controllers.Accounts
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IUserAccountService _userAccountService;
		public AccountController(IMapper mapper, IUserAccountService userAccountService)
		{
			_mapper = mapper;
			_userAccountService = userAccountService;
		}

		/// <summary>
		/// Register new user
		/// </summary>
		/// <param name="request">RegisterUserAccountRequest</param>
		/// <response code="200">Registered user model</response>
		[HttpPost("")]
		public async Task<UserAccountResponse> Register([FromBody] RegisterUserAccountRequest request)
		{
			var user = await _userAccountService.Create(_mapper.Map<RegisterUserAccountModel>(request));
			
			return _mapper.Map<UserAccountResponse>(user);
		}

		/// <summary>
		/// Change password
		/// </summary>
		/// <param name="request">ChangePasswordRequest</param>
		/// <response code="200">Success report</response>
		[HttpPatch("")]
		[Authorize]
		public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
		{
			var model = _mapper.Map<ChangePasswordModel>(request);
			await _userAccountService.ChangePassword(model, User);
			return Ok();
		}
	}
}
