using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPLearning.Services.UserAccount;

public class ChangePasswordModel
{
	public string OldPassword { get; set; }
	public string NewPassword { get; set; }
}

public class ChangePasswordMoledValidator : AbstractValidator<ChangePasswordModel>
{
	public ChangePasswordMoledValidator() 
	{

		RuleFor(x => x.NewPassword)
			.MinimumLength(6).WithMessage("Minimum password length is 6 chars")
			.MaximumLength(50).WithMessage("Password is too long");

		RuleFor(x => x.OldPassword)
			.MinimumLength(6).WithMessage("Minimum password length is 6 chars")
			.MaximumLength(50).WithMessage("Password is too long");
	}
}