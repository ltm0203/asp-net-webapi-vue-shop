using System;

using YoYoMooc.ECommerce.API.Data;
using YoYoMooc.ECommerce.API.Models;

namespace YoYoMooc.ECommerce.API.Services
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly EcommerceContext _context;

        public SQLProductRepository(EcommerceContext context)
        {
            this._context= context;
        }

        public Product CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product DeleteProduct(int id)
        {
           var product = _context.Products.Find(id);

            if (product == null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {

            return _context.Products;

        }

        public Product GetProductById(int id)
        {


        var product=    _context.Products.Find(id);
            return product;
        }

        public Product UpdateProduct(Product updateProduct)
        {
var product =_context.Products.Attach(updateProduct);
            product.State= Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updateProduct;
        }
    }


 



}
