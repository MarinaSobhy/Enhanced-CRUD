using CRUD.Models;
using CRUD.Queries;
using CRUD.Repositories;
using MediatR;

// CQRS allows us to scale read and write operations independently
// By separating read and write models, we can optimize each model for its specific purpose
// By segregating the concerns, CQRS simplifies the codebase and makes it easier to maintain and enhance over time
// we have the flexibility to choose different data stores for read and write operations based on their specific requirements

namespace CRUD.Handlers
{
    public class GetProductListHandler : IRequestHandler<GetProductListCommand, List<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductListHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Handle(GetProductListCommand query, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductList();
        }


    }
}
