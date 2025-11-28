using BloodBank.Application.Services;
using BloodBank.Domain.Entities;
using QuestPDF.Fluent;

namespace BloodBank.Infrastructure.ExternalServices.QuestPdf.DonationReports
{
    public class DonationsHistoryReportService : IDonationReportService
    {
        public byte[] GenerateDonationsHistoryReport(List<Donation> donations)
        {
            var document = new DonationsHistoryReportDocument(donations);
            return document.GeneratePdf();
        }
    }
}
