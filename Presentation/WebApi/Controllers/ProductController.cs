using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Abstraction;
using OnionArch.Application.Repostories.ProductRepositories;
using OnionArch.Application.ViewModels;
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
              new Product { Name = "Product A", Price = 100, Stock = 20},
 
       });
          await  _productWriteRepository.SaveAsync();
            var products =  _productReadRepository.GetAll();
            return Ok(products);

        }
        [HttpPost]
        public  ActionResult CreateProduct(ProductCreateVM product)
        {
           
            return Ok(product);
        }
    }
}
