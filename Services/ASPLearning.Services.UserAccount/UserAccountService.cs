using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPLearning.Context.Entities;
using ASPLearning.Common;
using AutoMapper;

namespace ASPLearning.Services.UserAccount
{
	internal class UserAccountService : IUserAccountService
	{
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;
		private readonly IModelValidator<RegisterUserAccountModel> _validator;

		public UserAccountService(UserManager<User> userManager, IMapper mapper, IModelValidator<RegisterUserAccountModel> validator)
		{
			_userManager = userManager;
			_mapper = mapper;
			_validator = validator;
		}

		public async Task<UserAccountModel> Create(RegisterUserAccountModel model)
		{
			_validator.Check(model);

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
