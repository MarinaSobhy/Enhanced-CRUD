using CRUD.Commands;
using CRUD.Repositories;
using MediatR;

namespace CRUD.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<int> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(command.ID);
            if (product == null)
                return default;

            return await _productRepository.DeleteProduct(product.ID);
        }
    }
}
