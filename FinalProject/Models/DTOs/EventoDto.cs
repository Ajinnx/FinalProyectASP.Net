using FinalProject.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models.DTOs;

/// <summary>
/// Versión 'Data Transfer Object' de <see cref="Evento"/>.
/// <br/><strong>Enviar (request)</strong>
/// <br/>Los objetos de tipo <see cref="Evento"/> se deben transformar a esta clase
/// mediante <see cref="ToDto(FinalProject.Models.Evento)"/> antes de ser
/// transferidos por la red.
/// <br/><strong>Recibir (response)</strong>
/// <br/>Una vez recibido, se puede transformar de vuelta mediante el
/// método <see cref="FromDto(FinalProject.Models.DTOs.EventoDto, AppDbContext)"/>.
/// </summary>
public sealed class EventoDto
{
    public int Id { get; set; }

    /// <summary>
    /// Identificador del <see cref="Models.UsuarioProveedor"/> que ha publicado
    /// este evento. <see langword="null"/> si no es un proveedor.
    /// </summary>

    public int? UsuarioProveedorId { get; set; }

    /// <summary>
    /// Identificador del <see cref="Models.UsuarioEmpresa"/> que ha publicado
    /// este evento. <see langword="null"/> si no es una empresa.
    /// </summary>

    public int? UsuarioEmpresaId { get; set; }

    /// <summary>
    /// Identificador del <see cref="Models.UsuarioOng"/> que ha publicado
    /// este evento. <see langword="null"/> si no es una ONG.
    /// </summary>

    public int? UsuarioOngId { get; set; }

    /// <summary>
    /// Lista de los identificadores de los usuarios receptores que se han suscrito al evento.
    /// </summary>
    public List<int> UsuariosReceptores { get; set; } = new();

    /// <summary>
    /// Un nombre común para el producto.
    /// </summary>
    public string NombreProducto { get; set; } = string.Empty;

    /// <summary>
    /// La cantidad de productos que están inicialmente disponibles.
    /// Este valor se especifica al crear un evento y no se debe modificar.
    /// </summary>
    public int CantidadPublicadaProducto { get; set; }

    /// <summary>
    /// La cantidad de productos actualmente disponibles.
    /// El valor baja conforme más usuarios receptores se suscriben.
    /// </summary>
    public int UnidadesRestantes { get; set; }

    /// <summary>
    /// La dirección a la que deben acudir los usuarios receptores para recoger el producto.
    /// <br/>Ejemplo: <c>C/ Calle 2, Barcelona</c>
    /// </summary>
    public string Direccion { get; set; } = string.Empty;

    /// <summary>
    /// La posición longitudinal del evento en el mapa del mundo.
    /// <br/>Propiedad relacionada con la API de Google Maps.
    /// </summary>
    [Precision(12, 7)]
    public decimal Longitud { get; set; }

    /// <summary>
    /// La posición latitudinal del evento en el mapa del mundo.
    /// <br/>Propiedad relacionada con la API de Google Maps.
    /// </summary>
    [Precision(12, 7)]
    public decimal Latitud { get; set; }

    /// <summary>
    /// La fecha y la hora a la que comienza este evento. Los usuarios receptores
    /// pueden venir a recoger el producto después de esta especificación.
    /// </summary>
    [Precision(0, 0)]
    public DateTime FechaHoraInicio { get; set; }

    /// <summary>
    /// La fecha y la hora a la que termina este evento. Los usuarios receptores
    /// pueden venir a recoger el producto antes de esta especificación.
    /// </summary>
    [Precision(0, 0)]
    public DateTime FechaHoraFin { get; set; }

    /// <summary>
    /// Determina si este evento consta de productos aptos para
    /// el desayuno, la comida, la merienda o la cena.
    /// </summary>
    public int CategoriaHoraria { get; set; }

    /// <summary>
    /// La lista de los identificadores de las posibles alergias presentes en el producto.
    /// </summary>
    public List<int> Alergias { get; set; } = new();

    /// <summary>
    /// Transforma un evento a una versión transferible por la red de éste.
    /// </summary>
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

    /// <summary>
    /// Transforma un evento transferido por la red a un evento regular.
    /// </summary>
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
