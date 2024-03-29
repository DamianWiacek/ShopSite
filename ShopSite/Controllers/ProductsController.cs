﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopSite.Entities;
using ShopSite.Models;
using ShopSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSite.Controllers
{
    [Route("api/ProductController")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<Product> GetById([FromRoute] int id)
        {
            var product = await _productService.GetById(id);
            return product;
        }
        [HttpGet("category/{category}")]
        public async Task<List<Product>> GetByCategory([FromRoute] ProductCategory category)
        {
            var products = await _productService.GetByCategory(category);
            return products;
        }
        [HttpGet("name/{name}")]
        [Authorize(Roles = "Customer")]
        public async Task<List<Product>> GetByName([FromRoute] string name)
        {
            var products = await _productService.GetByName(name);
            return products;
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        public async Task<List<Product>> GetAll()
        {
            var products = await _productService.GetAll();
            return products;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AddNewProduct([FromBody]NewProductDto newProduct)
        {
                        
            var id = await _productService.AddNewProduct(newProduct);
            return Created($"/api/ProductsController/{id}", null);
        }
     
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            await _productService.Delete(id);
            return NotFound();
        }
       
    }
}
