namespace ASPLearning.Api.Configuration;

using System.Runtime.CompilerServices;
using ASPLearning.Settings;
using ASPLearning.Services.Settings;


public static class SwaggerConfiguration
{
	public static IServiceCollection AddAppSwagger(this IServiceCollection services)
	{
		var settings = Settings.Load<SwaggerSettings>("Swagger");
		if (!settings.Enabled)
			return services;

		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen(options =>
		{
			var xmlFileName = "api.xml";
			var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
			options.IncludeXmlComments(xmlPath);
		});

		return services;
	}

	public static void UseAppSwagger(this WebApplication app)
	{
		SwaggerSettings settings = app.Services.GetService<SwaggerSettings>();

		if (!settings?.Enabled ?? true)
			return;

		app.UseSwagger();
		app.UseSwaggerUI();
	}
}
