using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models;

/// <summary>
/// Una publicación realizada por un <see cref="Models.UsuarioProveedor"/>,
/// <see cref="Models.UsuarioEmpresa"/> o <see cref="Models.UsuarioOng"/>
/// a la que se pueden suscribir <see cref="Models.UsuarioReceptor"/>.
/// </summary>
public sealed class Evento
{
    public int Id { get; set; }

    /// <summary>
    /// Identificador del <see cref="Models.UsuarioProveedor"/> que ha publicado
    /// este evento. <see langword="null"/> si no es un proveedor.
    /// </summary>
    public int? UsuarioProveedorId { get; set; }

    /// <summary>
    /// El usuario de tipo proveedor que ha publicado este evento.
    /// <br/>Puede ser <see langword="null"/> si el usuario es de un tipo distinto.
    /// <br/>En ese caso, comprobar cual de las otras propiedades no es nula:
    /// <list type="bullet">
    /// <item><see cref="UsuarioEmpresa"/></item>
    /// <item><see cref="UsuarioOng"/></item>
    /// </list>
    /// </summary>
    public UsuarioProveedor? UsuarioProveedor { get; set; }

    /// <summary>
    /// Identificador del <see cref="Models.UsuarioEmpresa"/> que ha publicado
    /// este evento. <see langword="null"/> si no es una empresa.
    /// </summary>
    public int? UsuarioEmpresaId { get; set; }

    /// <summary>
    /// El usuario de tipo empresa que ha publicado este evento.
    /// <br/>Puede ser <see langword="null"/> si el usuario es de un tipo distinto.
    /// <br/>En ese caso, comprobar cual de las otras propiedades no es nula:
    /// <list type="bullet">
    /// <item><see cref="UsuarioProveedor"/></item>
    /// <item><see cref="UsuarioOng"/></item>
    /// </list>
    /// </summary>
    public UsuarioEmpresa? UsuarioEmpresa { get; set; }

    /// <summary>
    /// Identificador del <see cref="Models.UsuarioOng"/> que ha publicado
    /// este evento. <see langword="null"/> si no es una ONG.
    /// </summary>
    public int? UsuarioOngId { get; set; }

    /// <summary>
    /// El usuario de tipo ONG que ha publicado este evento.
    /// <br/>Puede ser <see langword="null"/> si el usuario es de un tipo distinto.
    /// <br/>En ese caso, comprobar cual de las otras propiedades no es nula:
    /// <list type="bullet">
    /// <item><see cref="UsuarioProveedor"/></item>
    /// <item><see cref="UsuarioEmpresa"/></item>
    /// </list>
    /// </summary>
    public UsuarioOng? UsuarioOng { get; set; }

    /// <summary>
    /// Lista de los usuarios receptores que se han suscrito al evento.
    /// </summary>
    public List<UsuarioReceptor> UsuariosReceptores { get; set; } = new();

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
    public CategoriaHorariaEvento CategoriaHoraria { get; set; }

    /// <summary>
    /// La lista de posibles alergias presentes en el producto.
    /// </summary>
    public List<Alergia> Alergias { get; set; } = new();
}
