namespace ASPLearning.Context;

using Microsoft.Extensions.DependencyInjection;
using ASPLearning.Context;
using ASPLearning.Settings;
using ASPLearning.Context.Settings;

public static class DbServiesExtentions
{
	public static IServiceCollection AddAppDbContext(this IServiceCollection services)
	{
		var settings = ASPLearning.Settings.Settings.Load<AppDbSettings>("Database");
		services.AddSingleton(settings);

		var dbOptionsDelegate = DbContextOptionsFactory.Configure(settings.ConnectionString, settings.DbType);
		services.AddDbContextFactory<AppDbContext>(dbOptionsDelegate);

		return services;
	}
}
