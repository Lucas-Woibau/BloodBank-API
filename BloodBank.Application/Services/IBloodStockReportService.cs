using BloodBank.Domain.Entities;

namespace BloodBank.Application.Services
{
    public interface IBloodStockReportService 
    {
        byte[] GenerateBloodStockReport(List<BloodStock> bloodStocks);
    }
}
