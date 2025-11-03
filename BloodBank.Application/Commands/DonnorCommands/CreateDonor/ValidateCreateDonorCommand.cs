using BloodBank.Application.Models;
using BloodBank.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.DonnorCommands.CreateDonor
{
    public class ValidateCreateDonorCommand : IPipelineBehavior<CreateDonorCommand, ResultViewModel<int>>
    {
        private BloodBankDbContext _context;
        public ValidateCreateDonorCommand(BloodBankDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(CreateDonorCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var donorEmailExists = await _context.Donors.AnyAsync(d => d.Email == request.Email);

            if (donorEmailExists)
                return ResultViewModel<int>.Error("This email has already been registered.");

            return await next();
        }
    }
}
