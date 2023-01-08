namespace ASPLearning.Api.Configuration;

using System.Runtime.CompilerServices;
using ASPLearning.Settings;
using ASPLearning.Api.Settings;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

public static class SwaggerConfiguration
{
	private static readonly string _appTitle = "ASP Learning Api";
	public static IServiceCollection AddAppSwagger(this IServiceCollection services)
	{
		var settings = Settings.Load<SwaggerSettings>("Swagger");
		services.AddSingleton(settings);

		if (!settings.Enabled)
			return services;

		services.AddOptions<SwaggerGenOptions>()
			.Configure<IApiVersionDescriptionProvider>((options, provider) =>
			{
				foreach (var avd in provider.ApiVersionDescriptions)
				{
					options.SwaggerDoc(avd.GroupName, new OpenApiInfo
					{
						Version = avd.GroupName,
						Title = $"{_appTitle}"
					});
				}
			});
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

		app.UseSwagger(options =>
		{
			options.RouteTemplate = "api/{documentname}/api.yaml";
		});

		var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

		app.UseSwaggerUI(options =>
		{
			provider.ApiVersionDescriptions.ToList().ForEach(description =>
				options.SwaggerEndpoint($"/api/{description.GroupName}/api.yaml", description.GroupName.ToUpperInvariant())
				);
		});
	}
}
