using Microsoft.AspNetCore.Mvc;

namespace MathApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MathController : ControllerBase
{
    [HttpGet("square/{number}")]
    public IActionResult Square(int number)
    {
        if (number < 0)
        {
            return BadRequest(new
            {
                message = "El número no puede ser negativo."
            });
        }

        int square = number * number;

        return Ok(new
        {
            number = number,
            square = square
        });
    }
}