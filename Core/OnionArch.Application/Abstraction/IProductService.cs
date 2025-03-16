using OnionArch.Domain.Entities;

namespace OnionArch.Application.Abstraction
{
   public interface IProductService
    {
        public List<Product> GetProducts();
    }
}
