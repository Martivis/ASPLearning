using ASPLearning.Services.UserAccount;
using AutoMapper;
using FluentValidation;

namespace ASPLearning.Api.Controllers.Accounts;

public class ChangePasswordRequest
{
	public string OldPassword { get; set; }
	public string NewPassword { get; set; }
}

public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
{
	public ChangePasswordRequestValidator()
	{
		RuleFor(x => x.NewPassword)
			.MinimumLength(6).WithMessage("Minimum password length is 6 chars")
			.MaximumLength(50).WithMessage("Password is too long");

		RuleFor(x => x.OldPassword)
			.MinimumLength(6).WithMessage("Minimum password length is 6 chars")
			.MaximumLength(50).WithMessage("Password is too long");
	}
}

public class ChangePasswordRequestProfile : Profile
{
	public ChangePasswordRequestProfile()
	{
		CreateMap<ChangePasswordRequest, ChangePasswordModel>();
	}
}
