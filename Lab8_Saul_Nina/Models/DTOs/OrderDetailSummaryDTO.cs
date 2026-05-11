namespace Lab8_Saul_Nina.Models.DTOs;

public class OrderDetailSummaryDTO
{
    public int OrderId { get; set; }
    public string ProductName { get; set; } = null!;
    public int Quantity { get; set; }
}