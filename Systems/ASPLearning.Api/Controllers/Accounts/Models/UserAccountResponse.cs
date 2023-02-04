using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ASPLearning.Context.Entities;
using ASPLearning.Services.UserAccount;

namespace ASPLearning.Api.Controllers.Accounts;


public class UserAccountResponse
{
	public Guid Guid { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
}

public class UserAccountResponseProfile : Profile
{
	public UserAccountResponseProfile()
	{
		CreateMap<UserAccountModel, UserAccountResponse>()
			.ForMember(d => d.Guid, p => p.MapFrom(s => s.Guid))
			.ForMember(d => d.Name, p => p.MapFrom(s => s.Name))
			.ForMember(d => d.Email, p => p.MapFrom(s => s.Email));
	}
}