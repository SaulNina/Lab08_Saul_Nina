using Lab8_Saul_Nina.Models;
using Lab8_Saul_Nina.Models.DTOs;

namespace Lab8_Saul_Nina.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetProductByMinPriceAsync(decimal minPrice);
    Task<IEnumerable<ProductDetailDTO>> GetProductByOrderIdAsync(int orderId);
    Task<int> GetTotalQuantityByOrderIdAsync(int orderId);
    Task<Product?> GetMostExpensiveProductAsync();
    Task<decimal> GetAverageProductPriceAsync();
    Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync();
    Task<IEnumerable<OrderDetailSummaryDTO>> GetAllOrderDetailsAsync();
}