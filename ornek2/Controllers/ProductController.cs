using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ornek2.Data;
using ornek2.Models;

namespace ornek2.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = ApplicationContext.Products;
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetProductById([FromRoute(Name = "id")] int id)
        {
            var product = ApplicationContext
                .Products
                .Where(p => p.Id == id)
                .SingleOrDefault();
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            try
            {
                if (product is null)
                {
                    return BadRequest();
                }
                ApplicationContext
                    .Products
                    .Add(product);
                return StatusCode(201, product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name ="id")] int id, [FromBody] Product product)
        {
            try
            {
                if (product is null)
                {
                    return BadRequest();
                }
                var productToUpdate = ApplicationContext
                    .Products
                    .Find(p => p.Id.Equals(id));
                if (productToUpdate is null)
                {
                    return NotFound();
                }
                if (id != product.Id)
                {
                    return BadRequest();
                }
                productToUpdate.Name = product.Name;
                productToUpdate.Description = product.Description;
                productToUpdate.Price = product.Price;
                return Ok(productToUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteAllProducts()
        {
            try
            {
                ApplicationContext
                    .Products
                    .Clear();
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteOneProducts([FromRoute(Name ="id")] int id)
        {
            try
            {
                var productToDelete = ApplicationContext
                    .Products
                    .Find(p => p.Id.Equals(id));
                if (productToDelete is null)
                {
                    return NotFound();
                }
                ApplicationContext
                    .Products
                    .Remove(productToDelete);
                return NoContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name ="id")] int id, [FromBody] JsonPatchDocument<Product> productPatch)
        {
            try
            {
                if (productPatch is null)
                {
                    return BadRequest();
                }
                var productToUpdate = ApplicationContext
                    .Products
                    .Find(p => p.Id.Equals(id));
                if (productToUpdate is null)
                {
                    return NotFound();
                }
                if (id != productToUpdate.Id)
                {
                    return BadRequest();
                }
                productPatch.ApplyTo(productToUpdate);
                return Ok(productToUpdate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
