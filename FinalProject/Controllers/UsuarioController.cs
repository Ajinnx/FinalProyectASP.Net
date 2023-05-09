using FinalProject.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers;

[Route("api/usuario")]
[ApiController]
public sealed class UsuarioController : ControllerBase
{
	private readonly AppDbContext _context;

	public UsuarioController(AppDbContext context)
	{
		_context = context;
	}

	[HttpGet("{nombreUsuario}")]
	public IActionResult Get(string nombreUsuario)
	{
		object? encontrado = _context.UsuariosReceptores.Where(usuario => usuario.Usuario == nombreUsuario).FirstOrDefault();
		encontrado ??= _context.UsuariosProveedores.Where(usuario => usuario.Usuario == nombreUsuario).FirstOrDefault();
		encontrado ??= _context.UsuariosEmpresas.Where(usuario => usuario.Usuario == nombreUsuario).FirstOrDefault();
		encontrado ??= _context.UsuariosOngs.Where(usuario => usuario.Usuario == nombreUsuario).FirstOrDefault();

		return encontrado is null
			? NotFound()
			: Ok(encontrado);
	}
}
