using BloodBank.Application.Commands.DonnorCommands.CreateDonor;
using FluentValidation;

namespace BloodBank.Application.Validators.DonorValidators
{
    public class CreateDonorValidator : AbstractValidator<CreateDonorCommand>
    {
        public CreateDonorValidator()
        {
            RuleFor(d => d.Email)
                .EmailAddress()
                    .WithMessage("Invalid e-mail");

            RuleFor(d => d.BirthDate)
                .LessThanOrEqualTo(DateTime.Today)
                    .WithMessage("Invalid date.");

            RuleFor(d => d.BloodType)
                .IsInEnum()
                    .WithMessage("Invalid bloodtype.");

            RuleFor(d => d.RhFactor)
                .IsInEnum()
                    .WithMessage("Invalid rh factor.");
        }
    }
}
