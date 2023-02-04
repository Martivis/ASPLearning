using ASPLearning.Services.UserAccount;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPLearning.Api.Controllers.Accounts;

public class RegisterUserAccountRequest
{
	public string Name { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
}

public class RegisterUserAccountRequestValidator : AbstractValidator<RegisterUserAccountRequest>
{
	public RegisterUserAccountRequestValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty().WithMessage("User name is required");

		RuleFor(x => x.Email)
			.EmailAddress().WithMessage("Email is required");

		RuleFor(x => x.Password)
			.MinimumLength(6).WithMessage("Minimum password length is 6 chars")
			.MaximumLength(50).WithMessage("Password is too long");
	}
}

public class RegisterUserAccountProfile : Profile
{
	public RegisterUserAccountProfile()
	{
		CreateMap<RegisterUserAccountRequest, RegisterUserAccountModel>()
			.ForMember(d => d.Name, p => p.MapFrom(s => s.Name))
			.ForMember(d => d.Email, p => p.MapFrom(s => s.Email))
			.ForMember(d => d.Password, p => p.MapFrom(s => s.Password));
	}
}
