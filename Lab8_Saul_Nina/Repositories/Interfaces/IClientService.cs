using Lab8_Saul_Nina.Models;

namespace Lab8_Saul_Nina.Repositories.Interfaces;

public interface IClientService
{
    Task<IEnumerable<Client>> GetClientsByNameAsync(string name);
}