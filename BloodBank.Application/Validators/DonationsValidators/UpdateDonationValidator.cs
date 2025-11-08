using BloodBank.Application.Commands.DonationCommands.UpdateDonation;
using FluentValidation;

namespace BloodBank.Application.Validators.DonationsValidators
{
    public class UpdateDonationValidator  : AbstractValidator<UpdateDonationCommand>
    {
        public UpdateDonationValidator()
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
