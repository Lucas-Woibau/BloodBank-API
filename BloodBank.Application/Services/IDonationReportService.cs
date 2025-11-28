using BloodBank.Domain.Entities;

namespace BloodBank.Application.Services
{
    public interface IDonationReportService
    {
        byte[] GenerateDonationsHistoryReport(List<Donation> donations);
    }
}
