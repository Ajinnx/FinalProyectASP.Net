using FinalProject.Contexts;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers;

[Route("api/usuarios/ong")]
[ApiController]
public sealed class UsuarioOngsController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuarioOngsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioOng>>> GetUsuariosOngs()
    {
        return _context.UsuariosOngs == null
            ? (ActionResult<IEnumerable<UsuarioOng>>)NotFound()
            : (ActionResult<IEnumerable<UsuarioOng>>)await _context.UsuariosOngs.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioOng>> GetUsuarioOng(int id)
    {
        if (_context.UsuariosOngs == null)
            return NotFound();

        var usuarioOng = await _context.UsuariosOngs.FindAsync(id);

        return usuarioOng == null
            ? (ActionResult<UsuarioOng>)NotFound()
            : (ActionResult<UsuarioOng>)usuarioOng;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuarioOng(int id, UsuarioOng usuarioOng)
    {
        if (id != usuarioOng.Id)
            return BadRequest();

        _context.Entry(usuarioOng).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioOngExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioOng>> PostUsuarioOng(UsuarioOng usuarioOng)
    {
        if (_context.UsuariosOngs == null)
            return Problem("Entity set 'AppDbContext.UsuariosOngs'  is null.");

        _context.UsuariosOngs.Add(usuarioOng);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUsuarioOng", new { id = usuarioOng.Id }, usuarioOng);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuarioOng(int id)
    {
        if (_context.UsuariosOngs == null)
            return NotFound();

        var usuarioOng = await _context.UsuariosOngs.FindAsync(id);

        if (usuarioOng == null)
            return NotFound();

        _context.UsuariosOngs.Remove(usuarioOng);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UsuarioOngExists(int id)
    {
        return (_context.UsuariosOngs?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
