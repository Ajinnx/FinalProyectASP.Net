using FinalProject.Contexts;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers;

[Route("api/usuarios/ong")]
[ApiController]
public class UsuarioOngsController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuarioOngsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/UsuarioOngs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioOng>>> GetUsuariosOngs()
    {
        return _context.UsuariosOngs == null
            ? (ActionResult<IEnumerable<UsuarioOng>>)NotFound()
            : (ActionResult<IEnumerable<UsuarioOng>>)await _context.UsuariosOngs.ToListAsync();
    }

    // GET: api/UsuarioOngs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioOng>> GetUsuarioOng(int id)
    {
        if (_context.UsuariosOngs == null)
        {
            return NotFound();
        }
        var usuarioOng = await _context.UsuariosOngs.FindAsync(id);

        return usuarioOng == null ? (ActionResult<UsuarioOng>)NotFound() : (ActionResult<UsuarioOng>)usuarioOng;
    }

    // PUT: api/UsuarioOngs/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuarioOng(int id, UsuarioOng usuarioOng)
    {
        if (id != usuarioOng.Id)
        {
            return BadRequest();
        }

        _context.Entry(usuarioOng).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioOngExists(id))
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

    // POST: api/UsuarioOngs
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<UsuarioOng>> PostUsuarioOng(UsuarioOng usuarioOng)
    {
        if (_context.UsuariosOngs == null)
        {
            return Problem("Entity set 'AppDbContext.UsuariosOngs'  is null.");
        }
        _context.UsuariosOngs.Add(usuarioOng);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUsuarioOng", new { id = usuarioOng.Id }, usuarioOng);
    }

    // DELETE: api/UsuarioOngs/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuarioOng(int id)
    {
        if (_context.UsuariosOngs == null)
        {
            return NotFound();
        }
        var usuarioOng = await _context.UsuariosOngs.FindAsync(id);
        if (usuarioOng == null)
        {
            return NotFound();
        }

        _context.UsuariosOngs.Remove(usuarioOng);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UsuarioOngExists(int id)
    {
        return (_context.UsuariosOngs?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
