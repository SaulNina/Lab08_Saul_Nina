using Lab8_Saul_Nina.Models;
using Lab8_Saul_Nina.Models.DTOs;

namespace Lab8_Saul_Nina.Services.Interfaces;

public interface IClientService
{
    Task<IEnumerable<Client>> GetClientsByNameAsync(string name);
    Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date);
    Task<ClientOrderCountDTO?> GetTopClientAsync();
    Task<IEnumerable<string>> GetProductsByClientIdAsync(int clientId);
    Task<IEnumerable<string>> GetClientsByProductIdAsync(int productId);
}