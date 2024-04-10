using CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Repositories
{
    public class InMemoryProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public async Task<Product> AddProduct(Product product)
        {
            _products.Add(product); 
            return product;
        }

        public async Task<int> DeleteProduct(int id)
        {
            var product = _products.Where(x => x.ID == id).FirstOrDefault();
            _products.Remove(product);
            return id;
        }

        public async Task<Product> GetProductById(int id)
        {
            return  _products.Where(x => x.ID == id).FirstOrDefault(); 
        }

        public async Task<List<Product>> GetProductList()
        {
            return _products;
        }

        public async Task<int> UpdateProduct(Product product)
        {
            var oldProduct = _products.Where(x => x.ID == product.ID).FirstOrDefault();
            _products.Remove(oldProduct);
            _products.Add(product);
            return product.ID;
        }
    }
}
