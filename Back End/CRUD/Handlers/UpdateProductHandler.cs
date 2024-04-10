using CRUD.Commands;
using CRUD.Repositories;
using MediatR;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CRUD.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(command.ID);
            if (product == null)
                return default;

            product.Name = command.Name;
            product.Category = command.Category;
            product.Price = command.Price;
            product.Description = command.Description;

            return await _productRepository.UpdateProduct(product);
        }
    }
}
