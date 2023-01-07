namespace ASPLearning.Services.Settings;

using Microsoft.Extensions.DependencyInjection;
using ASPLearning.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


public static class Bootstraper
{
	public static IServiceCollection AddSwaggerSettings(this IServiceCollection services)
	{
		var settings = Settings.Load<SwaggerSettings>("Swagger");
		services.AddSingleton(settings);

		return services;
	}
}
