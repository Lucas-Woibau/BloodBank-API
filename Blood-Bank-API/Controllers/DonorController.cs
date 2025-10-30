using BloodBank.Application.Commands.DonnorCommands.CreateDonor;
using BloodBank.Application.Commands.DonnorCommands.DeleteDonor;
using BloodBank.Application.Commands.DonnorCommands.UpdateDonor;
using BloodBank.Application.Queries.DonorQueries.GetAllDonors;
using BloodBank.Application.Queries.DonorQueries.GetDonorById;
using BloodBank.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank_API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DonorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDonors()
        {
            var query = new GetAllDonorsQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetDonorByIdQuery(id);
            var result = await _mediator.Send(query);

            if(!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDonor(CreateDonorCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDonorCommand command)
        {
            var result = await _mediator.Send(command);

            if(!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteDonorCommand(id));

            if(!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
