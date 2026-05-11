namespace Lab8_Saul_Nina.Models.DTOs;

public class ClientOrderCountDTO
{
    public int ClientId { get; set; }
    public string ClientName { get; set; } = null!;
    public int TotalOrders { get; set; }
}