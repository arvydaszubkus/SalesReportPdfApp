using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SalesReportPdfApp.Models;
using SalesReportPdfApp.Pdf;

QuestPDF.Settings.License = LicenseType.Community;

var report = new MonthlySalesReport
{
    DateFrom = new DateTime(2025, 7, 1),
    DateTo = new DateTime(2025, 7, 31),
    Department = new Department { Id = 1, Name = "Electronics" },
    Sales = new List<SalesEntry>
    {
        new() { ProductName = "Laptop", Quantity = 5, UnitPrice = 800m, SaleDate = new DateTime(2025, 7, 3) },
        new() { ProductName = "Monitor", Quantity = 10, UnitPrice = 200m, SaleDate = new DateTime(2025, 7, 7) },
        new() { ProductName = "Keyboard", Quantity = 15, UnitPrice = 50m, SaleDate = new DateTime(2025, 7, 15) },
    }
};

var document = new MonthlySalesReportDocument(report);
document.GeneratePdf("MonthlySalesReport.pdf");