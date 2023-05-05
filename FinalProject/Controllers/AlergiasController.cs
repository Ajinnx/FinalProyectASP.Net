using FinalProject.Contexts;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers;

[Route("api/alergia")]
[ApiController]
public sealed class AlergiasController : ControllerBase
{
    private readonly AppDbContext _context;

    public AlergiasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Alergia>>> GetAlergias()
    {
        return _context.Alergias == null
            ? (ActionResult<IEnumerable<Alergia>>)NotFound()
            : (ActionResult<IEnumerable<Alergia>>)await _context.Alergias.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Alergia>> GetAlergia(int id)
    {
        if (_context.Alergias == null)
            return NotFound();

        var alergia = await _context.Alergias.FindAsync(id);

        return alergia == null ? (ActionResult<Alergia>)NotFound() : (ActionResult<Alergia>)alergia;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAlergia(int id, Alergia alergia)
    {
        if (id != alergia.Id)
            return BadRequest();

        _context.Entry(alergia).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AlergiaExists(id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Alergia>> PostAlergia(Alergia alergia)
    {
        if (_context.Alergias == null)
            return Problem("Entity set 'AppDbContext.Alergias'  is null.");

        _context.Alergias.Add(alergia);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAlergia", new { id = alergia.Id }, alergia);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAlergia(int id)
    {
        if (_context.Alergias == null)
            return NotFound();

        var alergia = await _context.Alergias.FindAsync(id);

        if (alergia == null)
            return NotFound();

        _context.Alergias.Remove(alergia);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AlergiaExists(int id)
    {
        return (_context.Alergias?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
