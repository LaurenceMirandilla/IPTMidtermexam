using FluentValidation;
using IPTMidtermexam.DTO.CustomerDTO;

namespace IPTMidtermexam.Validators.CustomerDTOValidator
{
    public class DeleteCustomerDTOValidator : AbstractValidator<DeleteCustomerDTO>
    {
        public DeleteCustomerDTOValidator()
        {
            RuleFor(x => x.CustomerID)
                .GreaterThan(0).WithMessage("CustomerID is required and must be greater than 0.");
        }
    }
}
