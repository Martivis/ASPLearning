namespace ASPLearning.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UsersDbContext>
{
    private const string migrationProjctPrefix = "ASPLearning.Context.Migrations";

    public UsersDbContext CreateDbContext(string[] args)
    {
        var provider = (args?[0] ?? $"{DbType.MSSQL}").ToLower();

        var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.context.json")
             .Build();


        DbContextOptions<UsersDbContext> options;
        if (provider.Equals($"{DbType.MSSQL}".ToLower()))
        {
            options = new DbContextOptionsBuilder<UsersDbContext>()
                    .UseSqlServer(
                        configuration.GetConnectionString(provider),
                        opts => opts
                            .MigrationsAssembly($"{migrationProjctPrefix}{DbType.MSSQL}")
                    )
                    .Options;
        }
        else
        if (provider.Equals($"{DbType.PostgreSQL}".ToLower()))
        {
            options = new DbContextOptionsBuilder<UsersDbContext>()
                    .UseNpgsql(
                        configuration.GetConnectionString(provider),
                        opts => opts
                            .MigrationsAssembly($"{migrationProjctPrefix}{DbType.PostgreSQL}")
                    )
                    .Options;
        }
        else
        {
            throw new Exception($"Unsupported provider: {provider}");
        }

        var dbf = new UsersDbContextFactory(options);
        return dbf.Create();
    }
}
