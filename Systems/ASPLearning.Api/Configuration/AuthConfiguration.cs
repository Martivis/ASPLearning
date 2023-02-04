using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using System.Runtime.CompilerServices;
using ASPLearning.Context.Entities;
using ASPLearning.Context;
using ASPLearning.Common.Security;
using IdentityServer4.AccessTokenValidation;
using ASPLearning.Api.Settings;
using Microsoft.IdentityModel.Tokens;

namespace ASPLearning.Api.Configuration;

public static class AuthConfiguration
{
	public static IServiceCollection AddAppAuth(this IServiceCollection services, IdentitySettings identitySettings)
	{
		IdentityModelEventSource.ShowPII = true;

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

		services.AddAuthentication(options =>
		{
			options.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
			options.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
		})
			.AddJwtBearer(IdentityServerAuthenticationDefaults.AuthenticationScheme, options =>
			{
				options.RequireHttpsMetadata = false;
				options.Authority = identitySettings.URL;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = false,
					ValidateIssuer = false,
					ValidateAudience = false,
					RequireExpirationTime = true,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero
				};
				options.Audience = "api";
			});

		services.AddAuthorization(options =>
		{
			options.AddPolicy(AppScopes.TextsRead, policy => policy.RequireClaim("scope", AppScopes.TextsRead));
			options.AddPolicy(AppScopes.TextsWrite, policy => policy.RequireClaim("scope", AppScopes.TextsWrite));
		});

		return services;
	}

	public static IApplicationBuilder UseAppAuth(this IApplicationBuilder app)
	{
		app.UseAuthentication();
		app.UseAuthorization();
		return app;
	}
}
