using CRUD.Handlers;
using CRUD.Models;
using CRUD.Queries;
using CRUD.Repositories;
using CRUDApiTest.Mocks;
using Moq;
using Shouldly;

namespace CRUDApiTest.Queries
{
    public class GetPrpductListHandlerTest
    {
        private readonly Mock<IProductRepository> _mockRepo;
        public GetPrpductListHandlerTest()
        {
            _mockRepo = MockProductRepository.GetProductRepo();
        }
        [Fact]
        public async Task GetProductlistTest() 
        {
            var handler = new GetProductListHandler(_mockRepo.Object);
            var result = await handler.Handle(new GetProductListCommand(),CancellationToken.None);
            result.ShouldBeOfType<List<Product>>();
            result.ShouldNotBeNull();
        }

    }
}
