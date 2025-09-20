using FluentValidation;
using IPTMidtermexam.DTO.TransactionDTO;

namespace IPTMidtermexam.Validators.TransactionDTOValidator
{
    public class DeleteTransactionDTOValidator : AbstractValidator<DeleteTransactionDTO>
    {
        public DeleteTransactionDTOValidator()
        {
            RuleFor(x => x.TransactionID)
                .GreaterThan(0).WithMessage("Transaction ID must be greater than 0.");

            RuleFor(x => x.IsDeleted)
                .Equal(true).WithMessage("IsDeleted should always be true for soft deletion.");
        }
    }
}
