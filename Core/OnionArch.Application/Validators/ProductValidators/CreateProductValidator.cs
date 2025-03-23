using FluentValidation;
using OnionArch.Application.ViewModels;

namespace OnionArch.Application.Validators.ProductValidators
{
   public class CreateProductValidator:AbstractValidator<ProductCreateVM>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Product Name is required");
            RuleFor(x => x.Price).NotNull().NotEmpty()
                .Must(x=>x>0)
                .WithMessage("Product Price is required");
            RuleFor(x => x.Stock).NotNull().NotEmpty().Must(x => x >= 0).WithMessage("Product Stock is required");
            
        }
    }
}
