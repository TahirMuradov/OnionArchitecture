using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionArch.Application.Abstraction;
using OnionArch.Application.Repostories.CustomerRepositories;
using OnionArch.Application.Repostories.OrderRepositories;
using OnionArch.Application.Repostories.ProductRepositories;
using OnionArch.Persistence.Concrete;
using OnionArch.Persistence.Context;
using OnionArch.Persistence.Repositories.CustomerRepositories;
using OnionArch.Persistence.Repositories.OrderRepositories;
using OnionArch.Persistence.Repositories.ProductRepositories;

namespace OnionArch.Persistence
{
   public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(Configration.DefaultConnectionString));

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();


            services.AddScoped<IProductService, ProductService>();
        }
    }
}
