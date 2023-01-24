using ASPLearning.Common.Security;
using Duende.IdentityServer.Models;

namespace ASPLearning.Identity.Configuration
{
	public static class AppApiScopes
	{
		public static IEnumerable<ApiScope> ApiScopes =>
			new List<ApiScope>
			{
				new ApiScope(AppScopes.TextsRead, "Access to texts API - Read texts"),
				new ApiScope(AppScopes.TextsWrite, "Access to texts API - Write texts")
			};
	}
}
