using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection;

namespace ASPLearning.Api.Configuration
{
	public class SelfHealthCheck : IHealthCheck
	{
		public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
		{
			var assembly = Assembly.Load("ASPLearning.Api");
			var version = assembly.GetName().Version;

			return Task.FromResult(HealthCheckResult.Healthy(description: $"Build {version}"));
		}
	}
}
