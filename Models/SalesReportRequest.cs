namespace SalesReportPdfApp.Models;

public class SalesReportRequest
{
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int DepartmentId { get; set; }
}
