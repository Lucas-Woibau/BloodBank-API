using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.DonationCommands.CreateDonation
{
    public class CreateDonationHandler : IRequestHandler<CreateDonationCommand, ResultViewModel<int>>
    {
        private readonly IDonationRepository _donationRepository;
        private readonly IBloodStockRepository _bloodStockRepository;
        private readonly IDonorRepository _donorRepository;

        public CreateDonationHandler(IDonationRepository donationRepository, IBloodStockRepository bloodStockRepository, IDonorRepository donorRepository)
        {
            _donationRepository = donationRepository;
            _bloodStockRepository = bloodStockRepository;
            _donorRepository = donorRepository;
        }

        public async Task<ResultViewModel<int>> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
        {
            var donor = await _donorRepository.GetById(request.IdDonor);

            if (donor == null)
                return ResultViewModel<int>.Error("Donor not found.");

            var bloodStock = await _bloodStockRepository
                .GetByBloodTypeAndRhFactor(donor.BloodType, donor.RhFactor);

            if (bloodStock == null)
                return ResultViewModel<int>.Error("Blood stock not found.");

            var donation = request.ToEntity();

            if (!bloodStock.AddDonation(donation.QuantityMl))
                return ResultViewModel<int>.Error("Invalid quantity for donate.");

            await _bloodStockRepository.Update(bloodStock);

            var id = await _donationRepository.Add(donation);

            return ResultViewModel<int>.Success(id);
        }
    }
}
