using Lab8_Saul_Nina.Models;
using Lab8_Saul_Nina.Models.DTOs;
using Lab8_Saul_Nina.Repositories.Interfaces;
using Lab8_Saul_Nina.Services.Interfaces;
namespace Lab8_Saul_Nina.Services;

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
    
    public async Task<IEnumerable<Order>> GetOrdersAfterDateAsync(DateTime date)
    {
        return await _unitOfWork.Orders.FindAsync(o => o.OrderDate > date);
    }
    
    public async Task<ClientOrderCountDTO?> GetTopClientAsync()
    {
        var orders = await _unitOfWork.Orders.FindAsync(o => true, o => o.Client);

        return orders
            .GroupBy(o => o.ClientId) 
            .Select(group => new ClientOrderCountDTO
            {
                ClientId = group.Key,
                ClientName = group.First().Client.Name,
                TotalOrders = group.Count()           
            })
            .OrderByDescending(dto => dto.TotalOrders) 
            .FirstOrDefault();                         
    }
    
    public async Task<IEnumerable<string>> GetProductsByClientIdAsync(int clientId)
    {
        var orders = await _unitOfWork.Orders.FindAsync(
            o => o.ClientId == clientId, 
            o => o.OrderDetails 
        );
        
        var details = await _unitOfWork.OrderDetails.FindAsync(
            od => od.Order.ClientId == clientId,
            od => od.Product 
        );

        return details
            .Select(od => od.Product.Name)
            .Distinct()
            .ToList();
    }
    
    public async Task<IEnumerable<string>> GetClientsByProductIdAsync(int productId)
    {
        var details = await _unitOfWork.OrderDetails.FindAsync(
            od => od.ProductId == productId,
            od => od.Order,        
            od => od.Order.Client  
        );
        
        return details
            .Select(od => od.Order.Client.Name)
            .Distinct()
            .ToList();
    }
}