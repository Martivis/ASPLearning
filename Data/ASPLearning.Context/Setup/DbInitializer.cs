using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPLearning.Context.Setup
{
	public static class DbInitializer
	{
		public static void Execute(IServiceProvider serviceProvider)
		{
			using var scope = serviceProvider.GetService<IServiceScopeFactory>()!.CreateScope();

			var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
			using var context = dbContextFactory.CreateDbContext();
			context.Database.Migrate();
		}
	}
}
