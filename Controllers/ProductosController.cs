using Microsoft.AspNetCore.Mvc;
using tiendaApi.Data;
using tiendaApi.Models;

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

    // GET: api/productos
    [HttpGet]
    public async Task<IActionResult> GetProductos()
    {
        var productos = await _repository.GetProductos();

        return Ok(productos);
    }

    // GET: api/productos/2
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProducto(int id)
    {
        var producto = await _repository.GetProducto(id);

        if (producto == null)
            return NotFound();

        return Ok(producto);
    }

    // POST: api/productos
    [HttpPost]
    public async Task<IActionResult> CrearProducto(Producto producto)
    {
        var id = await _repository.CrearProducto(producto);

        producto.Id = id;

        return CreatedAtAction(
            nameof(GetProducto),
            new { id = producto.Id },
            producto
        );
    }

    // PUT: api/productos/2
    [HttpPut("{id}")]
    public async Task<IActionResult> ActualizarProducto(
        int id,
        Producto producto)
    {
        var existente = await _repository.GetProducto(id);

        if (existente == null)
            return NotFound();

        producto.Id = id;

        await _repository.ActualizarProducto(producto);

        return Ok(producto);
    }

    // DELETE: api/productos/2
    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarProducto(int id)
    {
        var existente = await _repository.GetProducto(id);

        if (existente == null)
            return NotFound();

        await _repository.EliminarProducto(id);

        return NoContent();
    }
}