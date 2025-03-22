using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionArch.Application.Abstraction;
using OnionArch.Persistence.Concrete;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence
{
   public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(Configration.DefaultConnectionString));
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
