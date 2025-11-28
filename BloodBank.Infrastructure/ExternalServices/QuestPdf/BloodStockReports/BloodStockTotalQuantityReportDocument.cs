using BloodBank.Domain.Entities;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

public class BloodStockTotalQuantityReportDocument : IDocument
{
    private readonly List<BloodStock> _bloodStocks;

    public BloodStockTotalQuantityReportDocument(List<BloodStock> bloodStocks)
    {
        QuestPDF.Settings.License = LicenseType.Community;
        _bloodStocks = bloodStocks;
    }

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(25);

            page.Header().AlignCenter().Text("Total Quantity (mL) by Blood Type")
                .FontSize(20)
                .Bold();

            page.Content().PaddingTop(15).Table(table =>
            {
                table.ColumnsDefinition(col =>
                {
                    col.RelativeColumn();
                    col.RelativeColumn();
                    col.RelativeColumn();
                });

                table.Header(header =>
                {
                    header.Cell().Element(cell =>
                    {
                        cell
                        .BorderBottom(1)
                        .BorderColor("#444")
                        .PaddingVertical(6)
                        .AlignCenter()
                        .Text("Blood Type")
                        .Bold()
                        .FontSize(12);
                    });

                    header.Cell().Element(cell =>
                    {
                        cell
                        .BorderBottom(1)
                        .BorderColor("#444")
                        .PaddingVertical(6)
                        .AlignCenter()
                        .Text("Rh Factor")
                        .Bold()
                        .FontSize(12);
                    });

                    header.Cell().Element(cell =>
                    {
                        cell
                        .BorderBottom(1)
                        .BorderColor("#444")
                        .PaddingVertical(6)
                        .AlignCenter()
                        .Text("Quantity (mL)")
                        .Bold()
                        .FontSize(12);
                    });
                });

                foreach (var bloodStock in _bloodStocks)
                {
                    table.Cell().Element(cell =>
                    {
                        cell.BorderBottom(0.5f)
                            .BorderColor("#CCC")
                            .BorderVertical(0.5f)
                            .PaddingVertical(5)
                            .AlignCenter()
                            .Text(bloodStock.BloodType.ToString())
                            .FontSize(11);
                    });

                    table.Cell().Element(cell =>
                    {
                        cell.BorderBottom(0.5f)
                            .BorderColor("#CCC")
                            .BorderVertical(0.5f)
                            .PaddingVertical(5)
                            .AlignCenter()
                            .Text(bloodStock.RhFactor.ToString())
                            .FontSize(11);
                    });

                    table.Cell().Element(cell =>
                    {
                        cell.BorderBottom(0.5f)
                            .BorderColor("#CCC")
                             .BorderVertical(0.5f)
                            .PaddingVertical(5)
                            .AlignCenter()
                            .Text(bloodStock.QuantityMl.ToString())
                            .FontSize(11);
                    });
                }
            });
        });
    }
}
