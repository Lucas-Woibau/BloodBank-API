using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DonationCommands.CreateDonation
{
    public class ValidateCreateDonationCommand : IPipelineBehavior<CreateDonationCommand, ResultViewModel<int>>
    {
        private readonly IDonorRepository _donorRepository;
        private readonly IBloodStockRepository _bloodStockRepository;

        public ValidateCreateDonationCommand(IDonorRepository donorRepository, IBloodStockRepository bloodStockRepository)
        {
            _donorRepository = donorRepository;
            _bloodStockRepository = bloodStockRepository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateDonationCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetById(request.IdDonor);

            if (donor == null)
                return ResultViewModel<int>.Error("Donor not found");

            if (!donor.IsEligibleByAge())
                return ResultViewModel<int>.Error("Donor does not have minimum age to donate.");

            if (!donor.IsEligibleByWeight())
                return ResultViewModel<int>.Error("Donor does not have minimum weigth to donate.");

            var lastDonation = donor.Donations.OrderByDescending(d => d.DonationDate).FirstOrDefault();

            if (lastDonation != null)
            {
                var intervalNecessary = donor.GetDonationInterval();
                var daysFromLastDonation = (DateTime.Today - lastDonation.DonationDate).TotalDays;

                if (daysFromLastDonation < intervalNecessary)
                {
                    var missingDays = intervalNecessary - (int)daysFromLastDonation;
                    return ResultViewModel<int>.Error($"Wait {missingDays} days to donate again.");
                }
            }

            var donation = request.ToEntity();

            if (!donation.HasValidQuantity())
                return ResultViewModel<int>.Error($"Donation must be between 420 and 470 ml.");

            return await next();
        }
    }
}
