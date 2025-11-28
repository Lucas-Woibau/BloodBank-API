using BloodBank.Application.Services;
using BloodBank.Domain.Entities;
using QuestPDF.Fluent;

namespace BloodBank.Infrastructure.ExternalServices.QuestPdf.BloodStockReports
{
    public class BloodStockReportService : IBloodStockReportService
    {
        public byte[] GenerateBloodStockReport(List<BloodStock> bloodStocks)
        {
            var document = new BloodStockTotalQuantityReportDocument(bloodStocks);
            return document.GeneratePdf();
        }
    }
}
