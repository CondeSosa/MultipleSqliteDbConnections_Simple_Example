using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultipleSqliteDbConnections.SqliteManager.SqLiteManager.Contracts;
using MultipleSqliteDbConnections.SqliteManager.SqLiteManager.Services;
using MultipleSqliteDbConnections.SqLiteManager;

namespace MultipleSqliteDbConnections.SqliteManager
{
    public static class SqliteManagerServiceConfiguration
    {
        public static IServiceCollection AddSqliteManagerService(this IServiceCollection services)
        {
            services.AddScoped<ILocalDatabaseManagerService,LocalDatabaseManagerService>();
            services.AddTransient<ICompanyService, CompanyService>();
            return services;
        }
    }
}
