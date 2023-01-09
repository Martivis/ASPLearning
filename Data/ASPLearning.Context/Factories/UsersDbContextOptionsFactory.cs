using ASPLearning.Context.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPLearning.Context.Factories
{
	public static class UsersDbContextOptionsFactory
	{
		private const string migrationProjectPrefix = "ASPLearning.Context.Migrations";
		public static Action<DbContextOptionsBuilder> Configure(UsersDbSettings _settings)
		{
			return optionsBuilder =>
			{
				switch (_settings.DbType)
				{
					case DbType.MSSQL:
						optionsBuilder.UseSqlServer(
							_settings.ConnectionString,
							options =>
							{
								options.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
										.MigrationsHistoryTable("_EFMigrationsHistory", "public")
										.MigrationsAssembly($"{migrationProjectPrefix}{DbType.MSSQL}");
							});
						break;
					case DbType.PostgreSQL:
						optionsBuilder.UseNpgsql(
							_settings.ConnectionString,
							options =>
							{
								options.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
										.MigrationsHistoryTable("_EFMigrationsHistory", "public")
										.MigrationsAssembly($"{migrationProjectPrefix}{DbType.MSSQL}");
							});
						break;
				}
				optionsBuilder.EnableSensitiveDataLogging();
				optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			};
		}
	}
}
