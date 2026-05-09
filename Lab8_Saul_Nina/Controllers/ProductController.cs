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
}