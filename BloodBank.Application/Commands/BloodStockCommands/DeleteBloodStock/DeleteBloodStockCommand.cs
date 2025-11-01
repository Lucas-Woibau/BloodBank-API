using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Commands.BloodStockCommands.DeleteBloodStock
{
    public class DeleteBloodStockCommand : IRequest<ResultViewModel>
    {
        public DeleteBloodStockCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
