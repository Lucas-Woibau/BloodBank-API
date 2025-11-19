using BloodBank.Application.Models;
using BloodBank.Application.Services;
using BloodBank.Domain.Repositories;
using BloodBank.Domain.ValueObjects;
using MediatR;

namespace BloodBank.Application.Commands.DonnorCommands.CreateDonor
{
    public class CreateDonorHandler : IRequestHandler<CreateDonorCommand, ResultViewModel<int>>
    {
        private readonly IDonorRepository _repository;
        private readonly IZipCodeService _zipCodeService;

        public CreateDonorHandler(IDonorRepository repository, IZipCodeService zipCodeService)
        {
            _repository = repository;
            _zipCodeService = zipCodeService;
        }

        public async Task<ResultViewModel<int>> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
        {
            var zipCodeResult = await _zipCodeService.GetZipCode(request.Address.ZIPCode);
            if (zipCodeResult == null)
                return ResultViewModel<int>.Error("Zip Code not found.");

            var updatedAddress = new Address(
                request.Address.PublicPlace,
                zipCodeResult.City ?? request.Address.City,
                zipCodeResult.State ?? request.Address.State,
                zipCodeResult.Code ?? request.Address.ZIPCode
            );

            var donor = request.ToEntity(updatedAddress);

            var id = await _repository.Add(donor);

            return ResultViewModel<int>.Success(id);
        }
    }

}
