using BloodBank.Application.Services;
using BloodBank.Domain.Entities;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace BloodBank.Infrastructure.ExternalServices.QuestPdf
{
    public class ReportService : IReportService
    {
        public byte[] GenerateBloodStockReport(List<BloodStock> items)
        {
            var document = new BloodStockTotalQuantityReportDocument(items);
            return document.GeneratePdf();
        }
    }
}
