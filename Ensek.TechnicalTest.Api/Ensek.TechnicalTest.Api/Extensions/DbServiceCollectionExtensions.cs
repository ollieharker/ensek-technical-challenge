using Ensek.TechnicalTest.Db.Context;
using Microsoft.EntityFrameworkCore;

namespace Ensek.TechnicalTest.Api.Extensions
{
    public static class DbServiceCollectionExtensions
    {
        private static string EnsekDbConnectionStringApiKey = "EnsekApiDb";
        private static string EnsekDbMigrationsAssembly = "Ensek.TechnicalTest.Db";

        /// <summary>
        /// Add the required services for initializing the Ensek DB with a SQL Server provider.
        /// </summary>
        /// <param name="services">The services collection to registers services to.</param>
        /// <param name="configuration">The configuration to retrieve connection string details from.</param>
        /// <returns>The services collection utilized to register services with.</returns>
        public static IServiceCollection AddEnsekDbSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(EnsekDbConnectionStringApiKey);
            services.AddDbContext<EnsekDbContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly(EnsekDbMigrationsAssembly)));

            return services;
        }
    }
}
