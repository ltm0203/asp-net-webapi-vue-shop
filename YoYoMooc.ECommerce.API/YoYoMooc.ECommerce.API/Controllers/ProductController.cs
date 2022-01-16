using Microsoft.AspNetCore.Mvc;

using YoYoMooc.ECommerce.API.Models;
using YoYoMooc.ECommerce.API.Services;

namespace YoYoMooc.ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {

            

            return Ok(_productRepository.GetAllProducts());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _productRepository.GetProductById(id);

            


            if (product != null)
            {
                return product;
            }

            return NotFound();
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            var newProduct = _productRepository.CreateProduct(product);

            return Ok(newProduct);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(int id, Product updateProduct)
        {
            var model = _productRepository.GetProductById(id);
            if (model == null)
            {
                return NotFound();
            }

            var product = _productRepository.UpdateProduct(updateProduct);

            //  return NoContent();
            return product;
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var model = _productRepository.GetProductById(id);
            if (model == null)
            {
                return NotFound();
            }

            _productRepository.DeleteProduct(model.Id);

            return NoContent();
        }
    }
}