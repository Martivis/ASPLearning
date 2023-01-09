namespace ASPLearning.Context;

using Microsoft.Extensions.DependencyInjection;
using ASPLearning.Context.Factories;
using ASPLearning.Settings;
using ASPLearning.Context.Settings;

public static class DbBootstraper
{
	public static IServiceCollection AddAppUsersDb(this IServiceCollection services)
	{
		var settings = ASPLearning.Settings.Settings.Load<UsersDbSettings>("UsersDb");
		services.AddSingleton(settings);

		var dbOptionsDelegate = UsersDbContextOptionsFactory.Configure(settings);
		services.AddDbContextFactory<UsersDbContext>(dbOptionsDelegate);

		return services;
	}
}
