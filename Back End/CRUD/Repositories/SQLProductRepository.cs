using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;

// Why Repository Pattern
// The code is cleaner, and easier to reuse and maintain
// Enables us to create loosely coupled systems
// The repository pattern separates the data access logic from the rest of the application

namespace CRUD.Repositories
{
    public class SQLProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;

        public SQLProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> AddProduct(Product Product)
        {
            var result = _dbContext.Products.Add(Product);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteProduct(int id)
        {
            var product = _dbContext.Products.Where(x => x.ID == id).FirstOrDefault();
            _dbContext.Products.Remove(product);
            return await _dbContext.SaveChangesAsync();
        }


        public async Task<Product> GetProductById(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(p => p.ID == id);
        }

        public async Task<List<Product>> GetProductList()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<int> UpdateProduct(Product Product)
        {
            _dbContext.Products.Update(Product);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
