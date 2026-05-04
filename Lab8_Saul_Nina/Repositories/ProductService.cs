using Lab8_Saul_Nina.Models;
using Lab8_Saul_Nina.Repositories.Interfaces;

namespace Lab8_Saul_Nina.Repositories;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Product>> GetProductByMinPriceAsync(decimal minPrice)
    {
        return await _unitOfWork.Products.FindAsync(p => p.Price > minPrice);
    }
}