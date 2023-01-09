namespace ASPLearning.Context;

using Microsoft.Extensions.DependencyInjection;
using ASPLearning.Context;
using ASPLearning.Settings;
using ASPLearning.Context.Settings;

public static class DbBootstraper
{
	public static IServiceCollection AddAppUsersDb(this IServiceCollection services)
	{
		var settings = ASPLearning.Settings.Settings.Load<UsersDbSettings>("UsersDb");
		services.AddSingleton(settings);

		var dbOptionsDelegate = UsersDbContextOptionsFactory.Configure(settings.ConnectionString, settings.DbType);
		services.AddDbContextFactory<UsersDbContext>(dbOptionsDelegate);

		return services;
	}
}
