using Lab8_Saul_Nina.Models;
using Lab8_Saul_Nina.Models.DTOs;
using Lab8_Saul_Nina.Repositories.Interfaces;
using Lab8_Saul_Nina.Services.Interfaces;
namespace Lab8_Saul_Nina.Services;

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

    public async Task<IEnumerable<ProductDetailDTO>> GetProductByOrderIdAsync(int orderId)
    {
        var details = await _unitOfWork.OrderDetails.FindAsync(od => od.OrderId == orderId, od => od.Product);

        return details.Select(od => new ProductDetailDTO
        {
            ProductName = od.Product.Name,
            Quantity = od.Quantity,
        }).ToList();
    }
    
    public async Task<int> GetTotalQuantityByOrderIdAsync(int orderId)
    {
        var details = await _unitOfWork.OrderDetails.FindAsync(od => od.OrderId == orderId);

        return details.Sum(od => od.Quantity);
    }
    
    public async Task<Product?> GetMostExpensiveProductAsync()
    {
        var products = await _unitOfWork.Products.GetAllAsync();

        return products
            .OrderByDescending(p => p.Price)
            .FirstOrDefault();
    }
    
    public async Task<decimal> GetAverageProductPriceAsync()
    {
        var products = await _unitOfWork.Products.GetAllAsync();

        if (!products.Any()) return 0;

        return products.Average(p => p.Price);
    }
    
    public async Task<IEnumerable<Product>> GetProductsWithoutDescriptionAsync()
    {
        return await _unitOfWork.Products.FindAsync(p => 
            string.IsNullOrEmpty(p.Description));
    }
    
    public async Task<IEnumerable<OrderDetailSummaryDTO>> GetAllOrderDetailsAsync()
    {
        var details = await _unitOfWork.OrderDetails.FindAsync(
            od => true, 
            od => od.Product
        );

        return details.Select(od => new OrderDetailSummaryDTO
        {
            OrderId = od.OrderId,
            ProductName = od.Product.Name,
            Quantity = od.Quantity
        }).ToList();
    }
}