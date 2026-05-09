using Lab8_Saul_Nina.Models;

namespace Lab8_Saul_Nina.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductByMinPriceAsync(decimal minPrice);
}