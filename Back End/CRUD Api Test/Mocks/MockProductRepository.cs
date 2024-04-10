using CRUD.Models;
using CRUD.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApiTest.Mocks
{
    public static class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductRepo()
        {
            var products = new List<Product>
            {
                new Product
                {
                    ID = 1,
                    Name = "Test Product",
                    Price = 100,
                    Category = "Test Category",
                    Description = "Test Description"
                }
                
            };

            var mockRepo = new Mock<IProductRepository>();

            mockRepo.Setup(r => r.GetProductList()).ReturnsAsync(products);

            mockRepo.Setup(r => r.AddProduct(It.IsAny<Product>())).ReturnsAsync((Product product) =>
            {
                products.Add(product);
                return product;
            });

            return mockRepo;

        }
    }
}

