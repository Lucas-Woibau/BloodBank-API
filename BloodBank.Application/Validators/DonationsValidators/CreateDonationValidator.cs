using BloodBank.Application.Commands.DonationCommands.CreateDonation;
using FluentValidation;

namespace BloodBank.Application.Validators.DonationsValidators
{
    public class CreateDonationValidator : AbstractValidator<CreateDonationCommand>
    {
        public CreateDonationValidator()
        {
            RuleFor(d => d.DonationDate)
               .Must(date =>
               {
                   return date.ToUniversalTime().Date <= DateTime.UtcNow.Date;
               })
               .WithMessage("The donation date cannot be in the future.");
        }
    }
}
