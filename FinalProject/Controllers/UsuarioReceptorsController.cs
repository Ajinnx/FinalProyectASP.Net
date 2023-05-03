using FinalProject.Contexts;
using FinalProject.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers;

[Route("api/usuarios/receptor")]
[ApiController]
public class UsuarioReceptorsController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuarioReceptorsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioReceptorDto>>> GetUsuariosReceptores()
    {
        if (_context.UsuariosReceptores == null)
            return (ActionResult<IEnumerable<UsuarioReceptorDto>>)NotFound();


        var list = await _context.UsuariosReceptores.ToListAsync();
        return (ActionResult<IEnumerable<UsuarioReceptorDto>>)list.Select(UsuarioReceptorDto.ToDto).ToList();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioReceptorDto>> GetUsuarioReceptor(int id)
    {
        if (_context.UsuariosReceptores == null)
        {
            return NotFound();
        }
        var usuarioReceptor = await _context.UsuariosReceptores.FindAsync(id);

        return usuarioReceptor == null
            ? (ActionResult<UsuarioReceptorDto>)NotFound()
            : (ActionResult<UsuarioReceptorDto>)UsuarioReceptorDto.ToDto(usuarioReceptor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuarioReceptor(int id, UsuarioReceptorDto usuarioReceptorDto)
    {
        if (id != usuarioReceptorDto.Id)
        {
            return BadRequest();
        }

        _context.Entry(UsuarioReceptorDto.FromDto(usuarioReceptorDto, _context)).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioReceptorExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioReceptorDto>> PostUsuarioReceptor(UsuarioReceptorDto usuarioReceptorDto)
    {
        if (_context.UsuariosReceptores == null)
        {
            return Problem("Entity set 'AppDbContext.UsuariosReceptores'  is null.");
        }
        var usuario = _context.UsuariosReceptores.Add(UsuarioReceptorDto.FromDto(usuarioReceptorDto, _context));
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUsuarioReceptor", new { id = usuario.Entity.Id }, UsuarioReceptorDto.ToDto(usuario.Entity));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuarioReceptor(int id)
    {
        if (_context.UsuariosReceptores == null)
        {
            return NotFound();
        }
        var usuarioReceptor = await _context.UsuariosReceptores.FindAsync(id);
        if (usuarioReceptor == null)
        {
            return NotFound();
        }

        _context.UsuariosReceptores.Remove(usuarioReceptor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UsuarioReceptorExists(int id)
    {
        return (_context.UsuariosReceptores?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
