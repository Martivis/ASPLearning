using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ASPLearning.Context.Entities;

namespace ASPLearning.Services.UserAccount;


public class UserAccountModel
{
	public Guid Guid { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
}

public class UserAccountProfile : Profile
{
	public UserAccountProfile()
	{
		CreateMap<User, UserAccountModel>()
			.ForMember(d => d.Guid, o => o.MapFrom(s => s.Id))
			.ForMember(d => d.Name, o => o.MapFrom(s => s.UserName))
			.ForMember(d => d.Email, o => o.MapFrom(s => s.Email));
	}
}