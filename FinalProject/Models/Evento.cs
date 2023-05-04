using Microsoft.EntityFrameworkCore;

namespace FinalProject.Models;

public sealed class Evento
{
    public int Id { get; set; }
    public int? UsuarioProveedorId { get; set; }
    public UsuarioProveedor? UsuarioProveedor { get; set; }
    public int? UsuarioEmpresaId { get; set; }
    public UsuarioEmpresa? UsuarioEmpresa { get; set; }
    public int? UsuarioOngId { get; set; }
    public UsuarioOng? UsuarioOng { get; set; }
    public List<UsuarioReceptor> UsuariosReceptores { get; set; } = new();
    public string NombreProducto { get; set; } = string.Empty;
    public int CantidadPublicadaProducto { get; set; }
    public int UnidadesRestantes { get; set; }
    public string Direccion { get; set; } = string.Empty;

    [Precision(12, 7)]
    public decimal Longitud { get; set; }

    [Precision(12, 7)]
    public decimal Latitud { get; set; }

    [Precision(0, 0)]
    public DateTime FechaHoraInicio { get; set; }

    [Precision(0, 0)]
    public DateTime FechaHoraFin { get; set; }
    public CategoriaHorariaEvento CategoriaHoraria { get; set; }
    public List<Alergia> Alergias { get; set; } = new();
}
