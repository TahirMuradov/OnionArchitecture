using Microsoft.Extensions.DependencyInjection;
using OnionArch.Application.Abstraction;
using OnionArch.Persistence.Concrete;

namespace OnionArch.Persistence
{
   public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
