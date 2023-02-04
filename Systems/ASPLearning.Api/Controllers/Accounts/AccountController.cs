using ASPLearning.Common;
using ASPLearning.Services.UserAccount;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

		[HttpPost("")]
		public async Task<UserAccountResponse> Register([FromBody] RegisterUserAccountRequest request)
		{
			var user = await _userAccountService.Create(_mapper.Map<RegisterUserAccountModel>(request));
			
			return _mapper.Map<UserAccountResponse>(user);
		}
	}
}
