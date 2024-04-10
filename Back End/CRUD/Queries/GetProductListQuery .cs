using CRUD.Models;
using MediatR;

namespace CRUD.Queries
{
    public class GetProductListCommand : IRequest<List<Product>>
    {
    }
}
