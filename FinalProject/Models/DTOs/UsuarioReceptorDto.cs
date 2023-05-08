using FinalProject.Contexts;

namespace FinalProject.Models.DTOs;

public class UsuarioReceptorDto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string Dni { get; set; } = string.Empty;
    public string Contrasena { get; set; } = string.Empty;
    public List<int> Eventos { get; set; } = new();

    public static UsuarioReceptorDto ToDto(UsuarioReceptor usuarioReceptor)
    {
        return new()
        {
            Id = usuarioReceptor.Id,
            Nombre = usuarioReceptor.Nombre,
            Apellidos = usuarioReceptor.Apellidos,
            Dni = usuarioReceptor.Dni,
            Contrasena = usuarioReceptor.Contrasena,
            Eventos = usuarioReceptor.Eventos.Select(e => e.Id).ToList()
        };
    }

    public static UsuarioReceptor FromDto(UsuarioReceptorDto usuarioReceptorDto, AppDbContext context)
    {
        return new()
        {
            Id = usuarioReceptorDto.Id,
            Nombre = usuarioReceptorDto.Nombre,
            Apellidos = usuarioReceptorDto.Apellidos,
            Dni = usuarioReceptorDto.Dni,
            Contrasena = usuarioReceptorDto.Contrasena,
            Eventos = context.Eventos.Where(e => usuarioReceptorDto.Eventos.Contains(e.Id)).ToList()
        };
    }
}
