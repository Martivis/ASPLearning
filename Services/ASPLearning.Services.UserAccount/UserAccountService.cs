using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPLearning.Context.Entities;
using ASPLearning.Common;
using AutoMapper;
using System.Security.Claims;

namespace ASPLearning.Services.UserAccount
{
	internal class UserAccountService : IUserAccountService
	{
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;
		private readonly IModelValidator<RegisterUserAccountModel> _registerUserAccountModelValidator;
		private readonly IModelValidator<ChangePasswordModel> _changePasswordModelValidator;

		public UserAccountService(
			UserManager<User> userManager,
			IMapper mapper, 
			IModelValidator<RegisterUserAccountModel> validator, 
			IModelValidator<ChangePasswordModel> changePasswordModelValidator)
		{
			_userManager = userManager;
			_mapper = mapper;
			_registerUserAccountModelValidator = validator;
			_changePasswordModelValidator = changePasswordModelValidator;
		}

		public async Task ChangePassword(ChangePasswordModel model, ClaimsPrincipal issuer)
		{
			_changePasswordModelValidator.Check(model);

			var user = await _userManager.GetUserAsync(issuer)
				?? throw new Exception($"User  not found");

			var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
			if (!result.Succeeded)
			{
				var text = result.Errors.ToList().Select(a => a.Description).Aggregate((a, b) => a + "\n" + b);
				throw new Exception($"{text}");
			}
		}

		public async Task<UserAccountModel> Create(RegisterUserAccountModel model)
		{
			_registerUserAccountModelValidator.Check(model);

			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user != null)
				throw new Exception($"User account with email {model.Email} already exists");

			user = new User
			{
				UserName = model.Name,
				Email = model.Email,
				EmailConfirmed = true,
			};

			var result = await _userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded)
				throw new Exception("Operation failed");

			return _mapper.Map<UserAccountModel>(user);
		}
	}
}
