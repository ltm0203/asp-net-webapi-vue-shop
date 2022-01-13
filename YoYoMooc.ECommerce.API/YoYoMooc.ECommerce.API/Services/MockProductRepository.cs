using YoYoMooc.ECommerce.API.Models;

namespace YoYoMooc.ECommerce.API.Services
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> _productList;

        public MockProductRepository()
        {
                     _productList = new List<Product> {
                new Product { Name = "空调", Category = "分类1", Price = 100 },
                new Product { Name = "电视机", Category = "分类1", Price = 100 },
                new Product { Name = "油烟机", Category = "分类2", Price = 100 },
                new Product { Name = "冰箱", Category = "分类2", Price = 100 },
                new Product { Name = "猪肉", Category = "分类2", Price = 100 },
                new Product { Name = "牛肉", Category = "分类2", Price = 100 },
                                    };
        }

        public Product CreateProduct(Product product)
        {
            product.Id = _productList.Max(s => s.Id) + 1;
            _productList.Add(product);
            return product;
        }

        public Product DeleteProduct(int id)
        {
            var product = _productList.FirstOrDefault(s => s.Id == id);

            if (product != null)
            {
                _productList.Remove(product);
            }

            return product;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productList.AsEnumerable();
        }

        public Product GetProductById(int id)
        {
            return _productList.FirstOrDefault(a => a.Id == id);
        }

       

        public Product UpdateProduct(Product updateProduct)
        {
            var product = _productList.FirstOrDefault(s => s.Id == updateProduct.Id);

            if (product != null)
            {
                product.Price = updateProduct.Price;
                product.Name = updateProduct.Name;
                product.Category = updateProduct.Category;
                  
            }
            return product;
        }
    }
}