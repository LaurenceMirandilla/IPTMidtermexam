using FluentValidation;
using IPTMidtermexam.DTO.ProductDTO;

namespace IPTMidtermexam.Validators.ProductDTOValidator
{
    public class DeleteProductDTOValidator : AbstractValidator<DeleteProductDTO>
    {
        public DeleteProductDTOValidator()
        {
            RuleFor(x => x.ProductID)
                .GreaterThan(0).WithMessage("ProductID is required and must be greater than 0.");
        }
    }
}
