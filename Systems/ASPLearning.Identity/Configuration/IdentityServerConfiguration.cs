namespace ASPLearning.Identity.Configuration;

using ASPLearning.Context;
using ASPLearning.Context.Entities;
using Microsoft.AspNetCore.Identity;


public static class IdentityServerConfiguration
{
	public static IServiceCollection AddAppIdentityServer(this IServiceCollection services)
	{
		services.AddIdentity<User, IdentityRole<Guid>>(options =>
		{
			options.Password.RequiredLength = 8;
			options.Password.RequireDigit = true;
			options.Password.RequireLowercase = true;
			options.Password.RequireUppercase = true;
			options.Password.RequireNonAlphanumeric = false;
		})
			.AddEntityFrameworkStores<AppDbContext>()
			.AddUserManager<UserManager<User>>()
			.AddDefaultTokenProviders()
			;

		services.AddIdentityServer()
			.AddAspNetIdentity<User>()
			.AddInMemoryApiResources(AppResources.Resourses)
			.AddInMemoryApiScopes(AppApiScopes.ApiScopes)
			.AddInMemoryClients(AppClients.Clients)
			.AddInMemoryIdentityResources(AppIdentityResources.Resources)

			//.AddTestUsers(AppApiTestUsers.ApiUsers)

			.AddDeveloperSigningCredential();

		return services;
	}

	public static IApplicationBuilder UseAppIdentityServer(this IApplicationBuilder app)
	{
		app.UseIdentityServer();
		return app;
	}
}
