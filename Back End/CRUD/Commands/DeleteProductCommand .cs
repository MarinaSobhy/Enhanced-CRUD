using MediatR;

namespace CRUD.Commands
{
    public class DeleteProductCommand : IRequest<int>
    {
        public int ID { get; set; }
    }
}
