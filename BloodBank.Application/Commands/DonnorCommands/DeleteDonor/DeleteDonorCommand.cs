using BloodBank.Application.Models;
using MediatR;

namespace BloodBank.Application.Commands.DonnorCommands.DeleteDonor
{
    public class DeleteDonorCommand : IRequest<ResultViewModel>
    {
        public int Id { get; set; }
    }
}
