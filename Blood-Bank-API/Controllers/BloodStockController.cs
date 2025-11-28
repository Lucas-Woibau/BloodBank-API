using BloodBank.Application.Commands.BloodStockCommands.CreateBloodStock;
using BloodBank.Application.Commands.BloodStockCommands.DeleteBloodStock;
using BloodBank.Application.Commands.BloodStockCommands.UpdateBloodStock;
using BloodBank.Application.Queries.BloodStockQueries.GetAllBloodStocks;
using BloodBank.Application.Queries.BloodStockQueries.GetBloodStockById;
using BloodBank.Application.Queries.ReportQueries;
using BloodBank.Application.Queries.ReportQueries.GetTotalQuantityByBloodType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodStockController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BloodStockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllBloodStocksQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBloodStockByIdQuery(id);
            var result = await _mediator.Send(query);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBloodStockCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBloodStockCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteBloodStockCommand(id));

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpGet("report")]
        public async Task<IActionResult> Report()
        {
            var result = await _mediator.Send(new GetTotalQuantityByBloodTypeQuery());

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return File(
                result.Data,
                "application/pdf",
                "bloodstock-report.pdf"
            );
        }
    }
}
