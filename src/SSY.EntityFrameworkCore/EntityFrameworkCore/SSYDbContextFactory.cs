using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SSY.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class SSYDbContextFactory : IDesignTimeDbContextFactory<SSYDbContext>
{
    public SSYDbContext CreateDbContext(string[] args)
    {
        SSYEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<SSYDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new SSYDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var environmentVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../SSY.DbMigrator/"))
            .AddJsonFile($"appsettings{(string.IsNullOrEmpty(environmentVariable) ? string.Empty : $".{environmentVariable}")}.json", optional: false);

        return builder.Build();
    }
}
