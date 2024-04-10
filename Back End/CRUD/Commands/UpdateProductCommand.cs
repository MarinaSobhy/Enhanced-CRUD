using MediatR;
namespace CRUD.Commands
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public UpdateProductCommand(int id,string name, string actegory, float price, string description)
        {
            ID = id;
            Name = name;
            Category = actegory;
            Price = price;
            Description = description;
        }
    }
}
