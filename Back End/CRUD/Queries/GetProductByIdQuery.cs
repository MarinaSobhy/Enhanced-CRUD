using CRUD.Models;
using MediatR;

namespace CRUD.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int ID { get; set; }
    }
}
