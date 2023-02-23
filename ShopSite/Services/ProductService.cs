using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopSite.Entities;
using ShopSite.Models;
using ShopSite.Repositories;
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
        public Task Delete(int id);
        public Task<List<Product>> GetByCategory(ProductCategory category);
        public Task<List<Product>> GetAll();
        public Task<int> AddNewProduct(NewProductDto product);

    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
             
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _repository.GetById(id);

            if (product == null) return null;
            return product;
        }
        public async Task<List<Product>> GetByName(string name)
        {
            var products = await _repository.GetByName(name);
            if (products == null) return null;
            return products;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _repository.GetAll();
            if (products == null) return null;
            return products;
        }

        public async Task<List<Product>> GetByCategory(ProductCategory category)
        {
            var products = await _repository.GetByCategory(category);
            if (products.Count == 0) return null;
            return products;
        }

        public async Task<int> AddNewProduct(NewProductDto product)
        {
            var newProduct = _mapper.Map<Product>(product);
            _repository.AddNewProduct(newProduct);
            return newProduct.Id;
        }
        public async Task Delete(int id)
        {
            _repository.Delete(id);

        }
    }
}
