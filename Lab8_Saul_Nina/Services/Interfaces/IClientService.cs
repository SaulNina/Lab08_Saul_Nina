using Lab8_Saul_Nina.Models;

namespace Lab8_Saul_Nina.Services.Interfaces;

public interface IClientService
{
    Task<IEnumerable<Client>> GetClientsByNameAsync(string name);
}