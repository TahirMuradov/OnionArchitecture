using OnionArch.Application.Repostories.ProductRepositories;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Repositories.ProductRepositories
{
    public class ProductReadRepository :ReadRepository<Product> ,IProductReadRepository
    {
        public ProductReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
