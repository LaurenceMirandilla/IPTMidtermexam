using FluentValidation;
using IPTMidtermexam.DTO.ProductDTO;

namespace IPTMidtermexam.Validators.ProductDTOValidator
{
    public class UpdateProductDTOValidator : AbstractValidator<UpdateProductDTO>
    {
        public UpdateProductDTOValidator()
        {
            RuleFor(x => x.ProductID)
                .GreaterThan(0).WithMessage("ProductID is required and must be greater than 0.");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product Name is required.")
                .Length(1, 255).WithMessage("Product Name must be between 1 and 255 characters.")
                .When(x => !string.IsNullOrEmpty(x.ProductName)); // Only validate if ProductName is provided

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.")
                .When(x => x.Price > 0); // Only validate if Price is provided

            RuleFor(x => x.StockQuantity)
                .GreaterThanOrEqualTo(0).WithMessage("Stock Quantity cannot be negative.")
                .When(x => x.StockQuantity >= 0); // Only validate if StockQuantity is provided
        }
    }
}
