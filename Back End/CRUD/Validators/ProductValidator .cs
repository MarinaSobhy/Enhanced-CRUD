using CRUD.Models;
using FluentValidation;

namespace CRUD.Validators
{
    public class ProductValidator :  AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(product => product.Category).MaximumLength(20).WithMessage("Maximum Length is 20.");
            RuleFor(product => product.Price).NotEmpty().WithMessage("Price is required.");
        }
    }
}
