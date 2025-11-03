using BloodBank.Application.Commands.DonnorCommands.CreateDonor;
using FluentValidation;

namespace BloodBank.Application.Validators
{
    public class CreateDonorValidator : AbstractValidator<CreateDonorCommand>
    {
        public CreateDonorValidator()
        {
            RuleFor(d => d.Email)
                .EmailAddress()
                    .WithMessage("Invalid e-mail");
        }
    }
}
