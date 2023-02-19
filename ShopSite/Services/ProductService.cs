using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopSite.Entities;
using ShopSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSite.Services
{
    public interface IProductService
    {
        public Task<Product> GetById(int id);
        public Task<List<Product>> GetByName(string name);
        public Task<bool> Delete(int id);
        public Task<List<Product>> GetByCategory(ProductCategory category);
        public Task<List<Product>> GetAll();
        public Task<int> AddNewProduct(NewProductDto product);

    }
    public class ProductService : IProductService
    {
        private readonly ShopDbContext _dbContext;
        private readonly IMapper _mapper;
        public ProductService(ShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
             
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);

            if (product == null) return null;
            return product;
        }
        public async Task<List<Product>> GetByName(string name)
        {
            var products = await _dbContext.Products.Where(x=>x.Name.Contains(name)).ToListAsync();
            if (products == null) return null;
            return products;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _dbContext.Products.ToListAsync();
            if (products == null) return null;
            return products;
        }

        public async Task<List<Product>> GetByCategory(ProductCategory category)
        {
            var products = await _dbContext.Products.Where(p => p.Category == category).ToListAsync();
            if (products.Count == 0) return null;
            return products;
        }

        public async Task<int> AddNewProduct(NewProductDto product)
        {
            var newProduct = _mapper.Map<Product>(product);
            await _dbContext.Products.AddAsync(newProduct);
            await _dbContext.SaveChangesAsync();
            return newProduct.Id;
        }
        public async Task<bool> Delete(int id)
        {
            var product = await _dbContext.Products.SingleOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return false;
            }
            _dbContext.Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;

        }
    }
}
