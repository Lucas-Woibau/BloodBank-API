using BloodBank.Domain.Entities;
using QuestPDF.Infrastructure;

namespace BloodBank.Application.Services
{
    public interface IReportService 
    {
        byte[] GenerateBloodStockReport(List<BloodStock> items);
    }
}
