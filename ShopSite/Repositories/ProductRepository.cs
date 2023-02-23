using Microsoft.EntityFrameworkCore;
using ShopSite.Entities;
using ShopSite.Models;

namespace ShopSite.Repositories
{
    public interface IProductRepository
    {
        public Task<Product> GetById(int id);
        public Task<List<Product>> GetByName(string name);
        public Task<List<Product>> GetAll();
        public Task<List<Product>> GetByCategory(ProductCategory category);
        public Task AddNewProduct(Product product);
        public Task Delete(int id);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly ShopDbContext _dbContext;

        public ProductRepository(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> GetById(int id)
        {
            return await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);

        }
        public async Task<List<Product>> GetByName(string name)
        {
            return await _dbContext.Products.Where(x => x.Name.Contains(name)).ToListAsync();
            
        }

        public async Task<List<Product>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
           
        }

        public async Task<List<Product>> GetByCategory(ProductCategory category)
        {
            return await _dbContext.Products.Where(p => p.Category == category).ToListAsync();
            
        }

        public async Task AddNewProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
           
        }
        public async Task Delete(int id)
        {
            var product = await _dbContext.Products.SingleOrDefaultAsync(x => x.Id == id);
            _dbContext.Remove(product);
            await _dbContext.SaveChangesAsync();
            

        }
    }
}
