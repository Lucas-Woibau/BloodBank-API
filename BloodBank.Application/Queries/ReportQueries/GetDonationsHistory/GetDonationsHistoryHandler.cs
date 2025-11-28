using BloodBank.Application.Models;
using BloodBank.Application.Services;
using BloodBank.Domain.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.ReportQueries.GetDonationsHistory
{
    public class GetDonationsHistoryHandler : IRequestHandler<GetMonthDonationsHistoryQuery, ResultViewModel<byte[]>>
    {
        private readonly IDonationReportService _donationReportService;
        private readonly IDonationRepository _donationRepository;

        public GetDonationsHistoryHandler(IDonationReportService donationReportService,
            IDonationRepository donationRepository)
        {
            _donationReportService = donationReportService;
            _donationRepository = donationRepository;
        }

        public async Task<ResultViewModel<byte[]>> Handle(GetMonthDonationsHistoryQuery request, CancellationToken cancellationToken)
        {
            var donations = await _donationRepository.GetLast30Days();

            if (!donations.Any())
                return ResultViewModel<byte[]>.Error("There is no donation.");

            var pdfBytes = _donationReportService.GenerateDonationsHistoryReport(donations);

            return ResultViewModel<byte[]>.Success(pdfBytes);
        }
    }
}
