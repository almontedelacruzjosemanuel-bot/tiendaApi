using Microsoft.AspNetCore.Mvc;
using tiendaApi.Data;

namespace tiendaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly ProductoRepository _repository;

    public ProductosController(ProductoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductos()
    {
        var productos = await _repository.GetProductos();

        return Ok(productos);
    }
}