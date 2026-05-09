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
}