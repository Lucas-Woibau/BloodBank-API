using BloodBank.Application.Commands.DonnorCommands.UpdateDonor;
using FluentValidation;

namespace BloodBank.Application.Validators.DonorValidators
{
    public class UpdateDonorValidator : AbstractValidator<UpdateDonorCommand>
    {
        public UpdateDonorValidator()
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
