using BloodBank.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace BloodBank.Infrastructure.ExternalServices.QuestPdf.DonationReports
{
    internal class DonationsHistoryReportDocument : IDocument
    {
        private readonly List<Donation> _donations;

        public DonationsHistoryReportDocument(List<Donation> donations)
        {
            QuestPDF.Settings.License = LicenseType.Community;
            _donations = donations;
        }

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Margin(25);

                page.Header().AlignCenter().Text("Donations of the Month")
                    .FontSize(20)
                    .Bold();

                page.Content().PaddingTop(15).Table(table =>
                {
                    table.ColumnsDefinition(col =>
                    {
                        col.RelativeColumn();
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
                            .Text("Donor")
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
                            .Text("Gender")
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
                            .Text("Donation Date")
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
                            .Text("Quantity ML")
                            .Bold()
                            .FontSize(12);
                        });
                    });

                    foreach (Donation donation in _donations)
                    {
                        table.Cell().Element(cell =>
                        {
                            cell.BorderBottom(0.5f)
                                .BorderColor("#CCC")
                                .BorderVertical(0.5f)
                                .PaddingVertical(5)
                                .AlignCenter()
                                .Text(donation.Donor.Name.ToString())
                                .FontSize(11);
                        });

                        table.Cell().Element(cell =>
                        {
                            cell.BorderBottom(0.5f)
                                .BorderColor("#CCC")
                                .BorderVertical(0.5f)
                                .PaddingVertical(5)
                                .AlignCenter()
                                .Text(donation.Donor.Gender.ToString())
                                .FontSize(11);
                        });

                        table.Cell().Element(cell =>
                        {
                            cell.BorderBottom(0.5f)
                                .BorderColor("#CCC")
                                .BorderVertical(0.5f)
                                .PaddingVertical(5)
                                .AlignCenter()
                                .Text(donation.DonationDate.ToString("d"))
                                .FontSize(11);
                        });

                        table.Cell().Element(cell =>
                        {
                            cell.BorderBottom(0.5f)
                                .BorderColor("#CCC")
                                .BorderVertical(0.5f)
                                .PaddingVertical(5)
                                .AlignCenter()
                                .Text(donation.QuantityMl.ToString())
                                .FontSize(11);
                        });
                    }
                });
            });
        }
    }
}
