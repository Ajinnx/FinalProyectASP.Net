using FinalProject.Contexts;
using FinalProject.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers;

[Route("api/evento")]
[ApiController]
public sealed class EventoesController : ControllerBase
{
    private readonly AppDbContext _context;

    public EventoesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EventoDto>>> GetEventos()
    {
        if (_context.Eventos == null)
            return (ActionResult<IEnumerable<EventoDto>>)NotFound();

        var list = await _context.Eventos
            .Include(e => e.Alergias)
            .Include(e => e.UsuariosReceptores)
            .ToListAsync();

        return (ActionResult<IEnumerable<EventoDto>>)list.Select(EventoDto.ToDto).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventoDto>> GetEvento(int id)
    {
        if (_context.Eventos == null)
            return NotFound();

        var evento = await _context.Eventos
            .Include(e => e.Alergias)
            .Include(e => e.UsuariosReceptores)
            .Where(e => e.Id == id).FirstOrDefaultAsync();

        return evento == null
            ? (ActionResult<EventoDto>)NotFound()
            : (ActionResult<EventoDto>)EventoDto.ToDto(evento);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutEvento(int id, EventoDto eventoDto)
    {
        if (id != eventoDto.Id)
            return BadRequest();

        _context.Entry(EventoDto.FromDto(eventoDto, _context)).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EventoExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<EventoDto>> PostEvento(EventoDto eventoDto)
    {
        if (_context.Eventos == null)
            return Problem("Entity set 'AppDbContext.Eventos'  is null.");

        var evento = _context.Eventos.Add(EventoDto.FromDto(eventoDto, _context));
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEvento", new { id = evento.Entity.Id }, EventoDto.ToDto(evento.Entity));
    }

    [HttpPut("{idEvento}/{idUsuario}")]
    public IActionResult SuscribirseAEvento(int idEvento, int idUsuario)
    {
        var usuario = _context.UsuariosReceptores.Where(x => x.Id == idUsuario).First();
        _context.Eventos.Where(x => x.Id == idEvento).First().UsuariosReceptores.Add(usuario);
        _context.SaveChanges();

        return Accepted();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvento(int id)
    {
        if (_context.Eventos == null)
            return NotFound();

        var evento = await _context.Eventos.FindAsync(id);

        if (evento == null)
            return NotFound();

        _context.Eventos.Remove(evento);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EventoExists(int id)
    {
        return (_context.Eventos?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
