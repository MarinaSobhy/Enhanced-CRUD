using CRUD.Commands;
using CRUD.Handlers;
using CRUD.Models;
using CRUD.Queries;
using CRUD.Repositories;
using CRUDApiTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CRUDApiTest.Commands
{
    public class CreateProductHandlerTest
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly Product _product;
        private readonly CreateProductHandler _handler;
        public CreateProductHandlerTest()
        {
            _mockRepo = MockProductRepository.GetProductRepo();
            _handler = new CreateProductHandler(_mockRepo.Object);
            _product = new Product()
            {
                Name = "Test",
                Price = 200,
                Category = "Test Category",
                Description = ""
            };
        }
        [Fact]
        public async Task CareteProductTest()
        {
            var result = await _handler.Handle(new CreateProductCommand(_product.Name,_product.Category,_product.Price,_product.Description), CancellationToken.None);
            var products = await _mockRepo.Object.GetProductList();
            products.Count.ShouldBe(2);
            result.ShouldBeOfType<Product>();
            result.ShouldNotBeNull();
        }
    }
}
