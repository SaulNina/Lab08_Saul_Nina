using Lab8_Saul_Nina.Models;
using Lab8_Saul_Nina.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Lab8_Saul_Nina.Services.Interfaces;

namespace Lab8_Saul_Nina.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("buscar_por_nombre/{nombre}")]
    public async Task<IActionResult> GetByName(string nombre)
    {
        var result = await _clientService.GetClientsByNameAsync(nombre);
        return Ok(result);
    }
    
    [HttpGet("orders-after/{date}")]
    public async Task<ActionResult<IEnumerable<Order>>> GetOrdersAfter(DateTime date)
    {
        var orders = await _clientService.GetOrdersAfterDateAsync(date);
    
        if (orders == null || !orders.Any())
        {
            return NotFound($"No se encontraron pedidos después de la fecha: {date:yyyy-MM-dd}");
        }
    
        return Ok(orders);
    }
    
    [HttpGet("top-client")]
    public async Task<ActionResult<ClientOrderCountDTO>> GetTopClient()
    {
        var topClient = await _clientService.GetTopClientAsync();
    
        if (topClient == null)
        {
            return NotFound("No se encontraron pedidos registrados.");
        }
    
        return Ok(topClient);
    }
    
    [HttpGet("{clientId}/products")]
    public async Task<ActionResult<IEnumerable<string>>> GetProductsByClient(int clientId)
    {
        var productNames = await _clientService.GetProductsByClientIdAsync(clientId);
    
        if (productNames == null || !productNames.Any())
        {
            return NotFound($"El cliente {clientId} no tiene productos comprados.");
        }
    
        return Ok(productNames);
    }
    
    [HttpGet("product/{productId}/buyers")]
    public async Task<ActionResult<IEnumerable<string>>> GetClientsByProduct(int productId)
    {
        var clientNames = await _clientService.GetClientsByProductIdAsync(productId);
    
        if (clientNames == null || !clientNames.Any())
        {
            return NotFound($"No se encontraron clientes que hayan comprado el producto {productId}.");
        }
    
        return Ok(clientNames);
    }
}