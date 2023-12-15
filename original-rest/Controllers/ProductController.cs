using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using original_rest.Entity;

namespace original_rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
        List<Product> products = new List<Product>()
            {
                new Product { Id = 5, Name = "Kahve" },
            };
        [HttpGet]
        public IActionResult GetAllProduct()
        {
            _logger.LogInformation("GetAllProduct method is called");
            
            products.Add(new Product { Id = 1, Name = "Çikolata" });
            products.Add(new Product { Id = 2, Name = "Reçel" });
            products.Add(new Product { Id = 3, Name = "Helva" });
            products.Add(new Product { Id = 4, Name = "Lokum" });
            _logger.LogWarning("GetAllProduct method is finished");
            return Ok(products);
        }
        [HttpPost]
        public IActionResult AddProduct([FromBody]Product product)
        {
            _logger.LogInformation("AddProduct method is called");
            products.Add(product);
            _logger.LogWarning("AddProduct method is finished");
            return Ok(product);
        }
    }
}
