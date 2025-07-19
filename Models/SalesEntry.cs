namespace SalesReportPdfApp.Models;

public class SalesEntry
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
    public DateTime SaleDate { get; set; }
}
