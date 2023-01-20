using ASPLearning.Services.Texts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPLearning.Services;

public static class TextServicesExtentions
{
	public static IServiceCollection AddTextService(this IServiceCollection services)
	{
		services.AddSingleton<ITextService, TextService>();
		return services;
	}
}
