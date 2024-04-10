using CRUD.Models;
using MediatR;

namespace CRUD.Commands
{
    public class CreateProductCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public CreateProductCommand(string name, string actegory, float price, string description)
        {
            Name = name;
            Category = actegory;
            Price = price;
            Description = description;  
        }
    }
}
