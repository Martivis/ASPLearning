using ASPLearning.Common.Security;
using Duende.IdentityServer.Models;

namespace ASPLearning.Identity.Configuration
{
	public static class AppClients
	{
		public static IEnumerable<Client> Clients =>
			new List<Client>()
			{
				new Client()
				{
					ClientId = "swagger",
					ClientSecrets = { new Secret("secret".Sha256()) },
					AllowedGrantTypes = GrantTypes.ClientCredentials,
					AccessTokenLifetime = 60,
					AccessTokenType = AccessTokenType.Jwt,
					AllowedScopes =
					{
						AppScopes.TextsRead,
						AppScopes.TextsWrite,
					},

				},

				new Client()
				{
					ClientId = "frontend",
					ClientSecrets = { new Secret("secret".Sha256()), },
					AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
					AccessTokenLifetime = 60,
					AccessTokenType = AccessTokenType.Jwt,
					AllowOfflineAccess = true,
					RefreshTokenExpiration = TokenExpiration.Sliding,
					RefreshTokenUsage = TokenUsage.OneTimeOnly,
					SlidingRefreshTokenLifetime = 60,
					AbsoluteRefreshTokenLifetime = 360,
					AllowedScopes =
					{
						AppScopes.TextsRead,
						AppScopes.TextsWrite,
					}
				}
			};
	}
}
