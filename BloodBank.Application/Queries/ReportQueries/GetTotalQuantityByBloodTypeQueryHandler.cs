using BloodBank.Application.Models;
using BloodBank.Application.Services;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.ReportQueries
{
    public class GetTotalQuantityByBloodTypeQueryHandler : IRequestHandler<GetTotalQuantityByBloodTypeQuery, ResultViewModel<byte[]>>
    {
        private readonly IBloodStockRepository _repository;
        private readonly IReportService _reportService;

        public GetTotalQuantityByBloodTypeQueryHandler(
            IBloodStockRepository repository,
            IReportService reportService)
        {
            _repository = repository;
            _reportService = reportService;
        }

        public async Task<ResultViewModel<byte[]>> Handle(GetTotalQuantityByBloodTypeQuery request, CancellationToken cancellationToken)
        {
            var stocks = await _repository.GetAll();

            if (!stocks.Any())
                return ResultViewModel<byte[]>.Error("There is no Blood Stock available.");

            var pdfBytes = _reportService.GenerateBloodStockReport(stocks);

            return ResultViewModel<byte[]>.Success(pdfBytes);
        }
    }
}