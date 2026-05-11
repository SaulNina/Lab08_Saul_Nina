using Lab8_Saul_Nina.Models;
using Lab8_Saul_Nina.Models.DTOs;
using Lab8_Saul_Nina.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Lab8_Saul_Nina.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("filtro_precio/{precio}")]
    public async Task<IActionResult> GetByPrice(decimal precio)
    {
        var result = await _productService.GetProductByMinPriceAsync(precio);
        return Ok(result);
    }

    [HttpGet("order/{orderId}")]
    public async Task<ActionResult<IEnumerable<ProductDetailDTO>>> GetProductsByOrder(int orderId)
    {
        var results = await _productService.GetProductByOrderIdAsync(orderId);
        if (results == null || !results.Any())
        {
            return NotFound($"No se encontraron productos para la orden {orderId}");
        }

        return Ok(results);
    }
    
    [HttpGet("order/{orderId}/total-quantity")]
    public async Task<ActionResult<int>> GetTotalQuantityByOrder(int orderId)
    {
        var total = await _productService.GetTotalQuantityByOrderIdAsync(orderId);
    
        return Ok(new { OrderId = orderId, TotalQuantity = total });
    }
    
    [HttpGet("most-expensive")]
    public async Task<ActionResult<Product>> GetMostExpensiveProduct()
    {
        var product = await _productService.GetMostExpensiveProductAsync();
    
        if (product == null)
        {
            return NotFound("No hay productos registrados.");
        }
    
        return Ok(product);
    }
    
    [HttpGet("average-price")]
    public async Task<ActionResult<decimal>> GetAveragePrice()
    {
        var average = await _productService.GetAverageProductPriceAsync();
    
        return Ok(new { 
            Description = "Precio promedio de productos",
            AveragePrice = average 
        });
    }
    
    [HttpGet("no-description")]
    public async Task<ActionResult<IEnumerable<Product>>> GetWithoutDescription()
    {
        var products = await _productService.GetProductsWithoutDescriptionAsync();
    
        if (products == null || !products.Any())
        {
            return Ok("Todos los productos tienen una descripción asignada.");
        }
    
        return Ok(products);
    }
    
    [HttpGet("all-details")]
    public async Task<ActionResult<IEnumerable<OrderDetailSummaryDTO>>> GetAllDetails()
    {
        var results = await _productService.GetAllOrderDetailsAsync();
    
        if (results == null || !results.Any())
        {
            return NotFound("No se encontraron detalles de órdenes.");
        }
    
        return Ok(results);
    }
}