using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultipleSqliteDbConnections.SqlManager.Contracts;
using MultipleSqliteDbConnections.SqlManager.Services;

namespace MultipleSqliteDbConnections.SqlManager
{
    public static class SqlManagerServiceConfiguration
    {
        public static IServiceCollection AddSqlManagerService(this IServiceCollection services,IConfiguration configuration)
        {
            //Get the connection string from the appsettings.json file
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            //Register the connection string as a service
            services.AddDbContext<SqlManagerContext>(options => options.UseSqlServer(connectionString));


            services.AddScoped<IDatabasesService, DatabasesService>();


            return services;
        }
    }
}
