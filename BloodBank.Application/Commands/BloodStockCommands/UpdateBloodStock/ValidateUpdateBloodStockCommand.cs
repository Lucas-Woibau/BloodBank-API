using BloodBank.Application.Models;
using BloodBank.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.BloodStockCommands.UpdateBloodStock
{
    public class ValidateUpdateBloodStockCommand : IPipelineBehavior<UpdateBloodStockCommand, ResultViewModel>
    {
        private readonly IBloodStockRepository _repository;

        public ValidateUpdateBloodStockCommand(IBloodStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultViewModel> Handle(UpdateBloodStockCommand request, RequestHandlerDelegate<ResultViewModel> next, CancellationToken cancellationToken)
        {
            var bloodStock = await _repository.GetById(request.IdBloodStock);

            if (bloodStock == null)
                return ResultViewModel.Error("Blood Stock not found.");

            if (bloodStock.BloodType == request.BloodType)
                return await next();

            var alreadyExists = await _repository.ExistsByBloodTypeAndRhFactor(request.BloodType, request.RhFactor);

            if (alreadyExists)
                return ResultViewModel.Error("This blood type already has a registered stock.");

            return await next();
        }
    }
}
