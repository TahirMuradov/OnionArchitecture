using OnionArch.Application.Repostories.ProductRepositories;
using OnionArch.Domain.Entities;
using OnionArch.Persistence.Context;

namespace OnionArch.Persistence.Repositories.ProductRepositories
{
  public  class ProductWriteRepository:WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
