using FluentValidation;
using IPTMidtermexam.DTO.CustomerDTO;

namespace IPTMidtermexam.Validators.CustomerDTOValidator
{
    public class UpdateCustomerDTOValidator : AbstractValidator<UpdateCustomerDTO>
    {
        public UpdateCustomerDTOValidator()
        {
            RuleFor(x => x.CustomerID)
                .GreaterThan(0).WithMessage("CustomerID is required and must be greater than 0.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .Length(1, 50).WithMessage("First Name must be between 1 and 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.FirstName)); // Validates only when FirstName is provided

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .Length(1, 50).WithMessage("Last Name must be between 1 and 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.LastName)); // Validates only when LastName is provided

            RuleFor(x => x.ContactNumber)
                .Matches(@"^\+?[0-9]{7,15}$").WithMessage("Invalid Contact Number.")
                .When(x => !string.IsNullOrEmpty(x.ContactNumber)); // Validates only when ContactNumber is provided

            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Invalid email format.")
                .When(x => !string.IsNullOrEmpty(x.Email)); // Validates only when Email is provided
        }
    }
}

