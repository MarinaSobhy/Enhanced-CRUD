using CRUD.Commands;
using CRUD.Models;
using CRUD.Repositories;
using MediatR;

namespace CRUD.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = command.Name,
                Category = command.Category,
                Price = command.Price,
                Description = command.Description
            };

            return await _productRepository.AddProduct(product);
        }
    }
}
