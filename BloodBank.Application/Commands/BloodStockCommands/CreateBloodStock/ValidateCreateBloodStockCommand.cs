using BloodBank.Application.Models;
using BloodBank.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Application.Commands.BloodStockCommands.CreateBloodStock
{
    public class ValidateCreateBloodStockCommand : IPipelineBehavior<CreateBloodStockCommand, ResultViewModel<int>>
    {
        private BloodBankDbContext _context;
        public ValidateCreateBloodStockCommand(BloodBankDbContext context)
        {
            _context = context;
        }

        public async Task<ResultViewModel<int>> Handle(CreateBloodStockCommand request, RequestHandlerDelegate<ResultViewModel<int>> next, CancellationToken cancellationToken)
        {
            var bloodTypeStockExists = 
                await _context.BloodStock.AnyAsync(b => b.BloodType == request.BloodType);

            if (bloodTypeStockExists)
                return ResultViewModel<int>.Error("This blood stock has already been registered.");

            return await next();
        }
    }
}
