using CompanyEmployees.Contracts;
using Microsoft.EntityFrameworkCore;
using CompanyEmployees.Repository;

namespace CompanyEmployees.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        //public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        //    services.AddDbContext<RepositoryContext>(opts =>
        //        opts.UseSqlServer(configuration.GetConnectionString("sqlConnection"), b => b.MigrationsAssembly("CompanyEmployees")));

        public static void ConfigMySqlConnection(this IServiceCollection services, IConfiguration config)
        {
            var connection = config["ConnectionStrings:DatabaseConnection"];
            //var connection = config.GetConnectionString("DatabaseConnection");
            services.AddDbContext<RepositoryContext>(o => o.UseMySql(connection,
               MySqlServerVersion.LatestSupportedServerVersion
             ));
        }
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
           services.AddScoped<IRepositoryManager, RepositoryManager>();

    }
}
