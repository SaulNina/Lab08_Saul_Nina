using Lab8_Saul_Nina.Models;
using Lab8_Saul_Nina.Repositories.Interfaces;

namespace Lab8_Saul_Nina.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly Linqexample2Context _context;

    public IGenericRepository<Client> Clients { get; private set; }
    public IGenericRepository<Order> Orders { get; private set; }
    public IGenericRepository<OrderDetail> OrderDetails { get; private set; }
    public IGenericRepository<Product> Products { get; private set; }

    public UnitOfWork(Linqexample2Context context)
    {
        _context = context;
        Clients = new GenericRepository<Client>(_context);
        Orders = new GenericRepository<Order>(_context);
        OrderDetails = new GenericRepository<OrderDetail>(_context);
        Products = new GenericRepository<Product>(_context);
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}