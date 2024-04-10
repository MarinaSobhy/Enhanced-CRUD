using CRUD.Models;

namespace CRUD.Repositories
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProductList();
        public Task<Product> GetProductById(int id);
        public Task<Product> AddProduct(Product product);
        public Task<int> UpdateProduct(Product product);
        public Task<int> DeleteProduct(int id);
    }
}
