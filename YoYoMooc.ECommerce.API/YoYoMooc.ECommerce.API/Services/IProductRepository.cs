using YoYoMooc.ECommerce.API.Models;

 
namespace YoYoMooc.ECommerce.API.Services
{
    public interface IProductRepository
    {

 
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        Product CreateProduct(Product product);
        Product UpdateProduct(Product updateProduct);
        Product DeleteProduct(int id);
    }
}
