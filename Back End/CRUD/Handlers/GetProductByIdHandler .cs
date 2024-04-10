using CRUD.Models;
using CRUD.Queries;
using CRUD.Repositories;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CRUD.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductById(query.ID);
        }
    }
}
