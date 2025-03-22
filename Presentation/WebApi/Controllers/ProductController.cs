using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Abstraction;
using OnionArch.Application.Repostories.ProductRepositories;
using OnionArch.Domain.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;

        public ProductController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task< ActionResult<ICollection<Product>>> GetProducts() 
        { 
       await _productWriteRepository.AddRangeAsync(new()
       {
              new Product { Name = "Product 1", Price = 100, Stock = 20, CreatedDate = DateTime.UtcNow },
    new Product { Name = "Product 2", Price = 150, Stock = 15, CreatedDate = DateTime.UtcNow },
    new Product { Name = "Product 3", Price = 200, Stock = 30, CreatedDate = DateTime.UtcNow },
    new Product { Name = "Product 4", Price = 250, Stock = 25, CreatedDate = DateTime.UtcNow },
    new Product { Name = "Product 5", Price = 300, Stock = 10, CreatedDate = DateTime.UtcNow }
       });
            var products =  _productReadRepository.GetAll();
          await  _productWriteRepository.SaveAsync();
            return Ok(products);

        }
    }
}
