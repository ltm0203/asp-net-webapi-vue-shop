using Microsoft.AspNetCore.Mvc;

using YoYoMooc.ECommerce.API.Models;
using YoYoMooc.ECommerce.API.Services;

namespace YoYoMooc.ECommerce.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// 获取所有的产品列表信息
        /// </summary>
        /// <returns></returns>       
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Ok(_productRepository.GetAllProducts());
        }
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
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


        /// <summary>
        /// 创建一个产品信息
        /// </summary>
        /// <param name="product">产品实体信息</param>
        ///<returns>将会返回一个新的产品信息</returns>
        /// <remarks>
        /// 示例代码:
        ///
        ///     POST API/Product
        ///     {
        ///        "id": 1,
        ///        "name": "空调",
        ///        "category": "家用电器",
        ///        "price": 200
        ///     }
        ///
        /// </remarks>
        /// <response code="200">返回一个新的产品信息</response>
        /// <response code="400">如果产品信息没有通过验证</response>
        /// <response code="500">无法提交正确的产品信息到数据库中</response>

        [HttpPost]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

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

        [ApiExplorerSettings(GroupName = "v2")]
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