using FinalProject.Contexts;

namespace FinalProject.Models.DTOs;

public sealed class EventoDto
{
    public int Id { get; set; }
    public int? UsuarioProveedorId { get; set; }
    public int? UsuarioEmpresaId { get; set; }
    public int? UsuarioOngId { get; set; }
    public List<int> UsuariosReceptores { get; set; } = new();
    public string NombreProducto { get; set; } = string.Empty;
    public int CantidadPublicadaProducto { get; set; }
    public int UnidadesRestantes { get; set; }
    public string Direccion { get; set; } = string.Empty;
    public double Longitud { get; set; }
    public double Latitud { get; set; }
    public DateTime FechaHoraInicio { get; set; }
    public DateTime FechaHoraFin { get; set; }
    public int CategoriaHoraria { get; set; }
    public List<int> Alergias { get; set; } = new();

    public static EventoDto ToDto(Evento evento)
    {
        return new()
        {
            Id = evento.Id,
            UsuarioProveedorId = evento.UsuarioProveedorId ?? evento.UsuarioProveedor?.Id,
            UsuarioEmpresaId = evento.UsuarioEmpresaId ?? evento.UsuarioEmpresa?.Id,
            UsuarioOngId = evento.UsuarioOngId ?? evento.UsuarioOng?.Id,
            UsuariosReceptores = evento.UsuariosReceptores.Select(u => u.Id).ToList(),
            NombreProducto = evento.NombreProducto,
            CantidadPublicadaProducto = evento.CantidadPublicadaProducto,
            UnidadesRestantes = evento.UnidadesRestantes,
            Direccion = evento.Direccion,
            Longitud = evento.Longitud,
            Latitud = evento.Latitud,
            FechaHoraInicio = evento.FechaHoraInicio,
            FechaHoraFin = evento.FechaHoraFin,
            CategoriaHoraria = (int)evento.CategoriaHoraria,
            Alergias = evento.Alergias.Select(a => a.Id).ToList()
        };
    }

    public static Evento FromDto(EventoDto eventoDto, AppDbContext context)
    {
        return new()
        {
            Id = eventoDto.Id,
            UsuarioProveedorId = eventoDto.UsuarioProveedorId,
            UsuarioEmpresaId = eventoDto.UsuarioEmpresaId,
            UsuarioOngId = eventoDto.UsuarioOngId,
            UsuariosReceptores = context.UsuariosReceptores.Where(u => eventoDto.UsuariosReceptores.Contains(u.Id)).ToList(),
            NombreProducto = eventoDto.NombreProducto,
            CantidadPublicadaProducto = eventoDto.CantidadPublicadaProducto,
            UnidadesRestantes = eventoDto.UnidadesRestantes,
            Direccion = eventoDto.Direccion,
            Longitud = eventoDto.Longitud,
            Latitud = eventoDto.Latitud,
            FechaHoraInicio = eventoDto.FechaHoraInicio,
            FechaHoraFin = eventoDto.FechaHoraFin,
            CategoriaHoraria = (CategoriaHorariaEvento)eventoDto.CategoriaHoraria,
            Alergias = context.Alergias.Where(u => eventoDto.Alergias.Contains(u.Id)).ToList()
        };
    }
}
