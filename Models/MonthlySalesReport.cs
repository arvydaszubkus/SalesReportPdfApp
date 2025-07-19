namespace SalesReportPdfApp.Models;

public class MonthlySalesReport
{
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public Department Department { get; set; } = new();
    public List<SalesEntry> Sales { get; set; } = new();
    public decimal TotalSales => Sales.Sum(s => s.TotalPrice);
    public int TotalItems => Sales.Sum(s => s.Quantity);
    public int TotalUniqueProducts => Sales.Select(s => s.ProductName).Distinct().Count();
    public DateTime GeneratedOn { get; set; } = DateTime.Now;
}
