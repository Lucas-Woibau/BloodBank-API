using BloodBank.Application.Commands.DonnorCommands.CreateDonor;
using BloodBank.Application.Models;
using BloodBank.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.DonnorCommands.UpdateDonor
{
    public class ValidateUpdateDonorCommand : IPipelineBehavior<UpdateDonorCommand, ResultViewModel>
    {
        private BloodBankDbContext _context;
        public ValidateUpdateDonorCommand(BloodBankDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel> Handle(UpdateDonorCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var donorEmailExists = 
                await _context.Donors.AnyAsync(d => d.Email == request.Email && d.Id != request.IdDonor);

            if (donorEmailExists)
                return ResultViewModel.Error("This email has already been registered.");

            return await next();
        }
    }
}
