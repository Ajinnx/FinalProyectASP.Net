using FinalProject.Contexts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FinalProject.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class SuscribirController : ControllerBase
{
    private readonly AppDbContext _context;

    public SuscribirController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet("{idUsuario}/{idEvento}")]
    public IActionResult Get(int idUsuario, int idEvento)
    {
        var usuario = _context.UsuariosReceptores.Where(x => x.Id == idUsuario).FirstOrDefault();

        if (usuario is null)
            return NotFound();

        var suscritoAEvento = usuario.Eventos.Any(x => x.Id == idEvento);

        return Ok(suscritoAEvento);
    }

    [HttpPost("{idUsuario}/{idEvento}")]
    public IActionResult Post(int idUsuario, int idEvento)
    {
        var usuario = _context.UsuariosReceptores.Where(x => x.Id == idUsuario).FirstOrDefault();

        if (usuario is null)
            return NotFound();

        var suscritoAEvento = usuario.Eventos.Any(x => x.Id == idEvento);

        if (suscritoAEvento)
            return NoContent();

        var evento = _context.Eventos.Where(x => x.Id == idEvento).FirstOrDefault();

        if (evento is null)
            return NotFound();

        if (evento.UnidadesRestantes <= 0)
            return StatusCode(StatusCodes.Status304NotModified, "Ya no quedan unidades.");

        evento.UnidadesRestantes--;
        usuario.Eventos.Add(evento);
        
        try
        {
            _context.SaveChanges();
        }
        catch (Exception)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpDelete("{idUsuario}/{idEvento}")]
    public void Delete(int idUsuario, int idEvento)
    {

    }
}
