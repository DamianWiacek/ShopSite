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
        public Product GetById(int id);

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
            var products = _dbContext.Products.Where(x=>x.Name.Contains(name)).ToList();
            if (products == null) return null;
            return await Task.FromResult(products);
        }

        public List<Product> GetAll()
        {
            var products = _dbContext.Products.ToList();
            if (products == null) return null;
            return products;
        }

        public List<Product> GetByCategory(ProductCategory category)
        {
            var products = _dbContext.Products.Where(p => p.Category == category).ToList();
            if (products.Count == 0) return null;
            return products;
        }

        public int AddNewProduct(NewProductDto product)
        {
            var newProduct = _mapper.Map<Product>(product);
            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();
            return newProduct.Id;
        }
        public bool Delete(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(x => x.Id == id);
            if (product == null)
            {
                return false;
            }
            _dbContext.Remove(product);
            _dbContext.SaveChanges();
            return true;

        }
    }
}
