using CRUD.Models;
using CRUD.Queries;
using MediatR;
using System.Reflection;
using System.Diagnostics;

namespace CRUD.Decorators
{
    public class ProductQueryHandlerDecorator : IRequestHandler<GetProductListCommand, List<Product>>
    {
        private readonly IRequestHandler<GetProductListCommand, List<Product>> _innerHandler;
        private readonly ILogger<ProductQueryHandlerDecorator> _logger;

        public ProductQueryHandlerDecorator(IRequestHandler<GetProductListCommand, List<Product>> innerHandler,
            ILogger<ProductQueryHandlerDecorator> logger)
        {
            _innerHandler = innerHandler ;
            _logger = logger ;
        }


        public async Task<List<Product>> Handle(GetProductListCommand request, CancellationToken cancellationToken)
        {
            var result = await _innerHandler.Handle(request, cancellationToken);
            _logger.LogInformation("Products List Retrived", request);
            return result;
        }
    }
}
