using BloodBank.Application.Commands.DonationCommands.CreateDonation;
using BloodBank.Application.Commands.DonationCommands.DeleteDonation;
using BloodBank.Application.Commands.DonationCommands.UpdateDonation;
using BloodBank.Application.Commands.DonnorCommands.DeleteDonor;
using BloodBank.Application.Queries.DonationsQueries.GetAllDonations;
using BloodBank.Application.Queries.DonationsQueries.GetDonationById;
using BloodBank.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank_API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DonationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllDonationsQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetDonationByIdQuery(id);

            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDonationCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDonationCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteDonationCommand(id));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
