using Duende.IdentityServer.Services;
using System.Runtime.CompilerServices;

namespace ASPLearning.Identity.Configuration
{
	public static class CorsConfiguration
	{
		public static IServiceCollection AddAppCors(this IServiceCollection services)
		{
			services.AddSingleton<ICorsPolicyService>((container) =>
			{
				var logger = container.GetRequiredService<ILogger<DefaultCorsPolicyService>>();
				return new DefaultCorsPolicyService(logger)
				{
					AllowAll = true
				};
			});

			return services;
		}
	}
}
