using ASPLearning.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPLearning.Context.Setup
{
	public static class DbSeeder
	{
		public static void AddDemoData(IServiceProvider serviceProvider)
		{
			Task.Run(async () =>
			{
				await AddUsers(serviceProvider);
			});
		}
		private static async Task AddUsers(IServiceProvider serviceProvider)
		{
			await using var context = serviceProvider.GetService<IServiceScopeFactory>()!.CreateScope()
				.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContext();
			if (context.Users.Any())
				return;

			List<User> users = new List<User>
			{
				new User
				{
					Name = "Jarko",
					Email = "jaria@mail.ru"
				},
				new User
				{
					Name = "Lena",
					Email = "elenare@mail.ru"
				},
				new User
				{
					Name = "Statustas",
					Email = "alexanderpetr@mail.ru"
				}
			};

			context.Users.AddRange(users);
			context.SaveChanges();
		}
	}
}
