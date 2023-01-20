namespace ASPLearning.Services.Texts;

using FluentValidation;
using AutoMapper;
using ASPLearning.Context.Entities;

public class AddTextModel
{
	public string Title { get; set; }
	public string Text { get; set; }
}

public class AddTextModelValidator : AbstractValidator<AddTextModel>
{
	public AddTextModelValidator()
	{
		RuleFor(x => x.Title)
			.MinimumLength(5).WithMessage("Title should be longer than 5 symbols")
			.MaximumLength(50).WithMessage("Title should be shorter than 50 symbols")
		;
		RuleFor(x => x.Text)
			.MinimumLength(10).WithMessage("Text should be longer than 10 symbols")
		;
	}
}

public class AddTextModelProfile : Profile
{
	public AddTextModelProfile()
	{
		CreateMap<AddTextModel, Text>()
			.ForMember(target => target.Content, a => a.MapFrom(x => x.Text));
	}
}
