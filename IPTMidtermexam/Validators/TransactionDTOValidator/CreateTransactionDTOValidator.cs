using FluentValidation;
using IPTMidtermexam.DTO.TransactionDTO;

namespace IPTMidtermexam.Validators.TransactionDTOValidator
{
    public class CreateTransactionDTOValidator : AbstractValidator<CreateTransactionDTO>
    {
        public CreateTransactionDTOValidator()
        {
            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("Total Amount must be greater than 0.");

            RuleFor(x => x.AmountPaid)
                .GreaterThan(0).WithMessage("Amount Paid must be greater than 0.");

            RuleFor(x => x.ChangeGiven)
                .GreaterThanOrEqualTo(0).WithMessage("Change Given must be greater than or equal to 0.");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("Payment Method is required.")
                .MaximumLength(50).WithMessage("Payment Method cannot exceed 50 characters.");

        }
    }
}
