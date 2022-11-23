using Microsoft.AspNetCore.Authorization;
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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public Product GetById([FromRoute] int id)
        {
            var product = _productService.GetById(id);
            return product;
        }
        [HttpGet("category/{category}")]
        public List<Product> GetByCategory([FromRoute] ProductCategory category)
        {
            var products = _productService.GetByCategory(category);
            return products;
        }
        [HttpGet("name/{name}")]
        public List<Product> GetByName([FromRoute] string name)
        {
            var products = _productService.GetByName(name);
            return products;
        }

        [HttpGet]
        public List<Product> GetAll()
        {
            var products = _productService.GetAll();
            return products;
        }

        [HttpPost]
        public ActionResult AddNewProduct([FromBody]NewProductDto newProduct)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var id = _productService.AddNewProduct(newProduct);
            return Created($"/api/ProductsController/{id}", null);
        }
     
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct([FromRoute] int id)
        {
            var isDeleted = _productService.Delete(id);
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }
       
    }
}
