using BloodBank.Application.Models;
using BloodBank.Application.Services;
using BloodBank.Domain.Repositories;
using BloodBank.Domain.ValueObjects;
using MediatR;

namespace BloodBank.Application.Commands.DonnorCommands.UpdateDonor
{
    public class UpdateDonorHandler : IRequestHandler<UpdateDonorCommand, ResultViewModel>
    {
        private readonly IDonorRepository _repository;
        private readonly IZipCodeService _zipCodeService;

        public UpdateDonorHandler(IDonorRepository repository, IZipCodeService zipCodeService)
        {
            _repository = repository;
            _zipCodeService = zipCodeService;
        }

        public async Task<ResultViewModel> Handle(UpdateDonorCommand request, CancellationToken cancellationToken)
        {
            var donor = await _repository.GetById(request.IdDonor);

            if (donor == null)
                return ResultViewModel.Error("Donor not found.");

            var zipCodeResult = await _zipCodeService.GetZipCode(request.Address.ZIPCode);
            if (zipCodeResult == null)
                return ResultViewModel<int>.Error("Zip Code not found.");

            var updatedAddress = new Address(
                request.Address.PublicPlace,
                zipCodeResult.City ?? request.Address.City,
                zipCodeResult.State ?? request.Address.State,
                zipCodeResult.Code ?? request.Address.ZIPCode
            );

            donor.Update
                (request.Name, request.Email, request.BirthDate, request.Gender,
                request.Weight, request.BloodType, request.RhFactor, updatedAddress);

            await _repository.Update(donor);

            return ResultViewModel.Success();
        }
    }
}
