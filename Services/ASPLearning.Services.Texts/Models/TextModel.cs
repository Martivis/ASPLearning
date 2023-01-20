namespace ASPLearning.Services.Texts;

using ASPLearning.Context.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TextModel
{
	public Guid Guid { get; set; }
	public string Title { get; set; }
	public string Text { get; set; }
}

public class TextModelProfile : Profile
{
	public TextModelProfile()
	{
		CreateMap<Text, TextModel>()
			.ForMember(t => t.Text, a => a.MapFrom(x => x.Content))
			.ForMember(t => t.Guid, a => a.MapFrom(x => x.Uid));
	}
}