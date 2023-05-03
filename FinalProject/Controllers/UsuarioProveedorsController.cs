using FinalProject.Contexts;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers;

[Route("api/usuarios/proveedor")]
[ApiController]
public class UsuarioProveedorsController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuarioProveedorsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/UsuarioProveedors
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioProveedor>>> GetUsuariosProveedores()
    {
        return _context.UsuariosProveedores == null
            ? (ActionResult<IEnumerable<UsuarioProveedor>>)NotFound()
            : (ActionResult<IEnumerable<UsuarioProveedor>>)await _context.UsuariosProveedores.ToListAsync();
    }

    // GET: api/UsuarioProveedors/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioProveedor>> GetUsuarioProveedor(int id)
    {
        if (_context.UsuariosProveedores == null)
        {
            return NotFound();
        }
        var usuarioProveedor = await _context.UsuariosProveedores.FindAsync(id);

        return usuarioProveedor == null ? (ActionResult<UsuarioProveedor>)NotFound() : (ActionResult<UsuarioProveedor>)usuarioProveedor;
    }

    // PUT: api/UsuarioProveedors/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuarioProveedor(int id, UsuarioProveedor usuarioProveedor)
    {
        if (id != usuarioProveedor.Id)
        {
            return BadRequest();
        }

        _context.Entry(usuarioProveedor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioProveedorExists(id))
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

    // POST: api/UsuarioProveedors
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<UsuarioProveedor>> PostUsuarioProveedor(UsuarioProveedor usuarioProveedor)
    {
        if (_context.UsuariosProveedores == null)
        {
            return Problem("Entity set 'AppDbContext.UsuariosProveedores'  is null.");
        }
        _context.UsuariosProveedores.Add(usuarioProveedor);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUsuarioProveedor", new { id = usuarioProveedor.Id }, usuarioProveedor);
    }

    // DELETE: api/UsuarioProveedors/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuarioProveedor(int id)
    {
        if (_context.UsuariosProveedores == null)
        {
            return NotFound();
        }
        var usuarioProveedor = await _context.UsuariosProveedores.FindAsync(id);
        if (usuarioProveedor == null)
        {
            return NotFound();
        }

        _context.UsuariosProveedores.Remove(usuarioProveedor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UsuarioProveedorExists(int id)
    {
        return (_context.UsuariosProveedores?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
