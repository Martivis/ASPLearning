namespace ASPLearning.Api.Configuration;

using Microsoft.AspNetCore.Diagnostics.HealthChecks;
public static class HealthCheckConfiguration
{
	public static IServiceCollection AddAppHealthCheck(this IServiceCollection services)
	{
		services.AddHealthChecks()
			.AddCheck<SelfHealthCheck>("ASPLearning.Api");
		return services;
	}

	public static void UseAppHealthChecks(this WebApplication app)
	{
		app.MapHealthChecks("/health");
	}
}
