using FluentValidation;
using IPTMidtermexam.DTO.ProductDTO;

namespace IPTMidtermexam.Validators.ProductDTOValidator
{
    public class CreateProductDTOValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductDTOValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product Name is required.")
                .Length(1, 255).WithMessage("Product Name must be between 1 and 255 characters.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Stock Quantity cannot be negative.");
        }
    }
}
