using FinalProject.Contexts;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers;

[Route("api/usuarios/empresa")]
[ApiController]
public class UsuarioEmpresasController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsuarioEmpresasController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/UsuarioEmpresas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UsuarioEmpresa>>> GetUsuariosEmpresas()
    {
        return _context.UsuariosEmpresas == null
            ? (ActionResult<IEnumerable<UsuarioEmpresa>>)NotFound()
            : (ActionResult<IEnumerable<UsuarioEmpresa>>)await _context.UsuariosEmpresas.ToListAsync();
    }

    // GET: api/UsuarioEmpresas/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioEmpresa>> GetUsuarioEmpresa(int id)
    {
        if (_context.UsuariosEmpresas == null)
        {
            return NotFound();
        }
        var usuarioEmpresa = await _context.UsuariosEmpresas.FindAsync(id);

        return usuarioEmpresa == null ? (ActionResult<UsuarioEmpresa>)NotFound() : (ActionResult<UsuarioEmpresa>)usuarioEmpresa;
    }

    // PUT: api/UsuarioEmpresas/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUsuarioEmpresa(int id, UsuarioEmpresa usuarioEmpresa)
    {
        if (id != usuarioEmpresa.Id)
        {
            return BadRequest();
        }

        _context.Entry(usuarioEmpresa).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioEmpresaExists(id))
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

    // POST: api/UsuarioEmpresas
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<UsuarioEmpresa>> PostUsuarioEmpresa(UsuarioEmpresa usuarioEmpresa)
    {
        if (_context.UsuariosEmpresas == null)
        {
            return Problem("Entity set 'AppDbContext.UsuariosEmpresas'  is null.");
        }
        _context.UsuariosEmpresas.Add(usuarioEmpresa);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUsuarioEmpresa", new { id = usuarioEmpresa.Id }, usuarioEmpresa);
    }

    // DELETE: api/UsuarioEmpresas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuarioEmpresa(int id)
    {
        if (_context.UsuariosEmpresas == null)
        {
            return NotFound();
        }
        var usuarioEmpresa = await _context.UsuariosEmpresas.FindAsync(id);
        if (usuarioEmpresa == null)
        {
            return NotFound();
        }

        _context.UsuariosEmpresas.Remove(usuarioEmpresa);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UsuarioEmpresaExists(int id)
    {
        return (_context.UsuariosEmpresas?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
