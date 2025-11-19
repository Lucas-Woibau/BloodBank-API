using BloodBank.Application.Commands.DonnorCommands.CreateDonor;
using BloodBank.Application.Models;
using BloodBank.Application.Services;
using BloodBank.Domain.Entities;
using BloodBank.Domain.Repositories;
using BloodBank.Tests.Helpers;
using Moq;

namespace BloodBank.Tests.Application
{
    public class CreateDonorHandlerTests
    {
        [Fact]
        public async Task When_CreateDataDonor_Should_ReturnSuccess()
        {
            //Arrange
            var fakeDonor = FakeDataHelper.CreateFakerDonorV1();

            var command = new CreateDonorCommand
            {
                Name = fakeDonor.Name,
                Email = fakeDonor.Email,
                BirthDate = fakeDonor.BirthDate,
                Gender = fakeDonor.Gender,
                Weight = fakeDonor.Weight,
                BloodType = fakeDonor.BloodType,
                RhFactor = fakeDonor.RhFactor,
                Address = fakeDonor.Address
            };

            var expectedEntity = command.ToEntity();

            var donorRepository = new Mock<IDonorRepository>();
            donorRepository
                .Setup(r => r.Add(It.IsAny<Donor>()));

            var zipCodeRepository = new Mock<IZipCodeService>();
            zipCodeRepository
                 .Setup(z => z.GetZipCode(It.IsAny<string>()))
                 .ReturnsAsync(new ZipCodeResult
                 {
                     PublicPlace = fakeDonor.Address.PublicPlace,
                     City = fakeDonor.Address.City,
                     State = fakeDonor.Address.State,
                     Code = fakeDonor.Address.ZIPCode
                 });

            var handler = new CreateDonorHandler(donorRepository.Object, zipCodeRepository.Object);

            //Act
            var result = await handler.Handle(command, default);

            //Assert
            Assert.True(result.IsSuccess);

            donorRepository.Verify(r => r.Add(It.Is<Donor>(d =>
                d.Name == expectedEntity.Name &&
                d.Email == expectedEntity.Email &&
                d.BirthDate == expectedEntity.BirthDate &&
                d.Gender == expectedEntity.Gender &&
                d.Weight == expectedEntity.Weight &&
                d.BloodType == expectedEntity.BloodType &&
                d.RhFactor == expectedEntity.RhFactor
            )), Times.Once);
        }

        [Fact]
        public async Task When_DonorBirthDateIsFuture_Should_Fail()
        {
            var fakeDonor = FakeDataHelper.CreateFakerDonorV1();

            var command = new CreateDonorCommand
            {
                Name = fakeDonor.Name,
                Email = fakeDonor.Email,
                BirthDate = DateTime.Now.AddDays(1),
                Gender = fakeDonor.Gender,
                Weight = fakeDonor.Weight,
                BloodType = fakeDonor.BloodType,
                RhFactor = fakeDonor.RhFactor,
                Address = fakeDonor.Address
            };

            var repository = new Mock<IDonorRepository>();

            var pipeline = new ValidateCreateDonorCommand(repository.Object);

            //Act
            var result = await pipeline.Handle(command, default, default);

            //Assert
            Assert.False(result.IsSuccess);
            repository.Verify(r => r.Add(It.IsAny<Donor>()), Times.Never);
        }

    }
}
