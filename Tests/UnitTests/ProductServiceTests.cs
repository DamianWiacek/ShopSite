using AutoMapper;
using Microsoft.AspNetCore.Rewrite;
using Moq;
using ShopSite.Entities;
using ShopSite.Models;
using ShopSite.Repositories;
using ShopSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tests.UnitTests
{
    public class ProductServiceTests
    {
        private Mock<IProductRepository> repoMock = new();
        private Mock<IMapper> mapperMock = new();
        private ProductService service;
        public ProductServiceTests()
        {
            service = new(repoMock.Object, mapperMock.Object);
        }
        [Fact]
        public async Task AddNewProduct_ForCorrectData_InvokeAddProducts()
        {
            //Arrange
            var productDto = new NewProductDto()
            {
                Name = "Fish",
                Description = "Salmon",
                Category = ProductCategory.Food,
                Price = 50.0,
                PhotoLink = "NoPhoto"
            };
            var product = new Product() { Id = 1 };
            mapperMock.Setup(x => x.Map<Product>(productDto)).Returns(product);
            //Act
            var result = await service.AddNewProduct(productDto);

            //Assert
            repoMock.Verify(x => x.AddNewProduct(product));
        }
        [Fact]
        public async Task GetById_ForCorrectId_ReturnProduct()
        {
            //Arrange
            var id = 1;
            repoMock.Setup(x => x.GetById(id)).ReturnsAsync(new Product()
            {
                Id = 1,
                Name = "Fish",
                Description = "Salmon",
                Category = ProductCategory.Food,
                Price = 50.0,
                PhotoLink = "NoPhoto"
            });

            //Act
            var result = await service.GetById(id);

            //Assert
            Assert.Equal(id, result.Id);

        }
        [Fact]
        public async Task GetById_ForIncorrectId_ReturnNull()
        {
            //Arrange
            var id = 1;
            repoMock.Setup(x => x.GetById(id)).ReturnsAsync((Product)null);

            //Act
            var result = await service.GetById(id);

            //Assert
            Assert.Equal(null, result);

        }
        [Fact]
        public async Task GetAll_IfProductsExists_ReturnAllProducts()
        {
            //Arrange
            var products = new List<Product>();
            products.Add(new Product { Id = 1 });
            products.Add(new Product { Id = 2 });
            repoMock.Setup(x => x.GetAll()).ReturnsAsync(products);

            //Act
            var result = await service.GetAll();

            //Assert
            Assert.Equal(products, result);

        }
        [Fact]
        public async Task GetAll_ForNoProducts_ReturnNull()
        {
            //Arrange
            var emptyList = new List<Product>();
            repoMock.Setup(x => x.GetAll()).ReturnsAsync(emptyList);

            //Act
            var result = await service.GetAll();

            //Assert
            Assert.Equal(null, result);

        }
        [Fact]
        public async Task GetByName_ForCorrectName_ReturnProducts()
        {
            //Arrange
            var name = "Fish";
            var products = new List<Product>();
            products.Add(new Product { Id = 1, Name="Fish"});
            repoMock.Setup(x => x.GetByName(name)).ReturnsAsync(products);

            //Act
            var result = await service.GetByName(name);

            //Assert
            Assert.True(result.Count>0);

        }
        [Fact]
        public async Task GetByName_ForNoProductsWithGivenName_ReturnNull()
        {
            //Arrange
            var name = "Water";
            var products = new List<Product>();
            repoMock.Setup(x => x.GetByName(name)).ReturnsAsync(products);

            //Act
            var result = await service.GetByName(name);

            //Assert
            Assert.Equal(null, result);

        }
        [Fact]
        public async Task GetByCategory_ForCorrectCategory_ReturnProduct()
        {
            //Arrange
            var category = ProductCategory.Clothes;
            var products = new List<Product>();
            products.Add(new Product { Id = 1, Category = ProductCategory.Clothes });
            products.Add(new Product { Id = 2, Category = ProductCategory.Clothes });
            repoMock.Setup(x => x.GetByCategory(category)).ReturnsAsync(products);

            //Act
            var result = await service.GetByCategory(category);

            //Assert
            Assert.Equal(products, result);

        }
        [Fact]
        public async Task GetByCategory_ForIncorrectCategory_ReturnNull()
        {
            //Arrange
            var category = ProductCategory.Clothes;
            var products = new List<Product>();
            repoMock.Setup(x => x.GetByCategory(category)).ReturnsAsync(products);

            //Act
            var result = await service.GetByCategory(category);

            //Assert
            Assert.Equal(null, result);

        }

    }
}
