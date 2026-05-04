using Lab8_Saul_Nina.Models;
using Lab8_Saul_Nina.Repositories.Interfaces;

namespace Lab8_Saul_Nina.Repositories;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Client>> GetClientsByNameAsync(string name)
    {
        return await _unitOfWork.Clients.FindAsync(c => c.Name.Contains(name));
    }
}