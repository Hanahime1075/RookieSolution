using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rookie.Ecom.DataAccessor.Data;

namespace Rookie.Ecom.DataAccessor
{
    public static class ServiceRegister
    {
        public static void AddDataAccessorLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EcomDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"), b =>
                    b.MigrationsAssembly(typeof(EcomDbContext).Assembly.FullName)
                ));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
