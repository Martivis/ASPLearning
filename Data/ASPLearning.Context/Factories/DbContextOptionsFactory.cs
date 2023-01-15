namespace ASPLearning.Context;

using ASPLearning.Context.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class DbContextOptionsFactory
{
	private const string migrationProjectPrefix = "ASPLearning.Context.Migrations";

	public static DbContextOptions<AppDbContext> Create(string connectionString, DbType dbType)
	{
		var builder = new DbContextOptionsBuilder<AppDbContext>();
		Configure(connectionString, dbType).Invoke(builder);
		return builder.Options;
	}

	public static Action<DbContextOptionsBuilder> Configure(string connectionString, DbType dbType)
	{
		return optionsBuilder =>
		{
			switch (dbType)
			{
				case DbType.MSSQL:
					optionsBuilder.UseSqlServer(
						connectionString,
						options =>
						{
							options.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
									.MigrationsHistoryTable("_EFMigrationsHistory", "dbo")
									.MigrationsAssembly($"{migrationProjectPrefix}{DbType.MSSQL}");
						});
					break;
				case DbType.PostgreSQL:
					optionsBuilder.UseNpgsql(
						connectionString,
						options =>
						{
							options.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds)
									.MigrationsHistoryTable("_EFMigrationsHistory", "public")
									.MigrationsAssembly($"{migrationProjectPrefix}{DbType.PostgreSQL}");
						});
					break;
			}
			optionsBuilder.EnableSensitiveDataLogging();
			optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
		};
	}
}
