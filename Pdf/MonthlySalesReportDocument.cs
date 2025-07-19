using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using SalesReportPdfApp.Models;

namespace SalesReportPdfApp.Pdf;

public class MonthlySalesReportDocument : IDocument
{
    private readonly MonthlySalesReport _report;

    public MonthlySalesReportDocument(MonthlySalesReport report)
    {
        _report = report;
    }

    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(30);
            page.Header().Text($"Monthly Sales Report - {_report.Department.Name}")
                .FontSize(20).Bold().FontColor(Colors.Blue.Medium);

            page.Content().Column(col =>
            {
                col.Spacing(10);

                col.Item().Text($"Report Period: {_report.DateFrom:yyyy-MM-dd} to {_report.DateTo:yyyy-MM-dd}");
                col.Item().Text($"Generated On: {_report.GeneratedOn:yyyy-MM-dd HH:mm}");
                col.Item().Text($"Total Sales: {_report.TotalSales:C}");
                col.Item().Text($"Total Items Sold: {_report.TotalItems}");
                col.Item().Text($"Unique Products Sold: {_report.TotalUniqueProducts}");

                col.Item().LineHorizontal(1).LineColor(Colors.Grey.Medium);

                col.Item().Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(150);
                        columns.ConstantColumn(60);
                        columns.ConstantColumn(80);
                        columns.ConstantColumn(80);
                        columns.ConstantColumn(100);
                    });

                    table.Header(header =>
                    {
                        header.Cell().Text("Product").Bold();
                        header.Cell().Text("Qty").Bold();
                        header.Cell().Text("Unit Price").Bold();
                        header.Cell().Text("Total").Bold();
                        header.Cell().Text("Date").Bold();
                    });

                    foreach (var sale in _report.Sales)
                    {
                        table.Cell().Text(sale.ProductName);
                        table.Cell().Text(sale.Quantity.ToString());
                        table.Cell().Text(sale.UnitPrice.ToString("C"));
                        table.Cell().Text(sale.TotalPrice.ToString("C"));
                        table.Cell().Text(sale.SaleDate.ToString("yyyy-MM-dd"));
                    }
                });
            });

            page.Footer().AlignCenter().Text("Sales Report PDF generated with QuestPDF");
        });
    }
}
