using ASPLearning.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
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
				await AddExampleData(serviceProvider);
			});
		}

		private static async Task AddExampleData(IServiceProvider serviceProvider)
		{
			await using var context = serviceProvider.GetService<IServiceScopeFactory>()!.CreateScope()
				.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>().CreateDbContext();
			if (context.Users.Any() || context.Texts.Any())
				return;

			//List<User> users = new List<User>
			//{
			//	new User
			//	{
			//		Name = "Jarko",
			//		Email = "jaria@mail.ru"
			//	},
			//	new User
			//	{
			//		Name = "Lena",
			//		Email = "elenare@mail.ru"
			//	},
			//	new User
			//	{
			//		Name = "Statustas",
			//		Email = "alexanderpetr@mail.ru"
			//	}
			//};

			List<Text> texts = new List<Text>
			{
				new Text
				{
					Title = "Example text",
					Content = "This is an example text for testing database work."
				},
				new Text
				{
					Title = "Random symbols",
					Content = "wt ErtSI sgw swpt gkW qA }S sfww .zx gwis z;afgj ruw 'apweo ktwi a'wper"
				}
			};
			foreach (var text in texts)
			{
				text.Size = text.Content.Length;
			}

			//context.Users.AddRange(users);
			context.Texts.AddRange(texts);
			context.SaveChanges();
		}
	}
}
