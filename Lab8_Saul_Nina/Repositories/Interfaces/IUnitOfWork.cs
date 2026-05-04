using Lab8_Saul_Nina.Models;

namespace Lab8_Saul_Nina.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Client> Clients { get; }
    IGenericRepository<Order> Orders { get; }
    IGenericRepository<OrderDetail> OrderDetails { get; }
    IGenericRepository<Product> Products { get; }
    
    Task<int> CompleteAsync();
}