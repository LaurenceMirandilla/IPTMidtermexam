using FluentValidation;
using IPTMidtermexam.DTO.CustomerDTO;

namespace IPTMidtermexam.Validators.CustomerDTOValidator
{
    public class CreateCustomerDTOValidator : AbstractValidator<CreateCustomerDTO>
    {
        public CreateCustomerDTOValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .Length(1, 50).WithMessage("First Name must be between 1 and 50 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .Length(1, 50).WithMessage("Last Name must be between 1 and 50 characters.");

            RuleFor(x => x.ContactNumber)
                .NotEmpty().WithMessage("Contact Number is required.")
                .Matches(@"^\+?[0-9]{7,15}$").WithMessage("Invalid Contact Number.")
                .Length(7, 15).WithMessage("Contact Number must be between 7 and 15 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
    }
}
