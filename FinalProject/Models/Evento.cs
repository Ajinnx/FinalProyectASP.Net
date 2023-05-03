namespace FinalProject.Models;

public sealed class Evento
{
    public int Id { get; set; }
    public int? UsuarioProveedorId { get; set; }
    public UsuarioProveedor? UsuarioProveedor { get; set; }
    public int? UsuarioEmpresaId { get; set; }
    public UsuarioProveedor? UsuarioEmpresa { get; set; }
    public int? UsuarioOngId { get; set; }
    public UsuarioOng? UsuarioOng { get; set; }
    public List<UsuarioReceptor> UsuariosReceptores { get; set; } = new();
    public string NombreProducto { get; set; } = string.Empty;
    public int CantidadPublicadaProducto { get; set; }
    public int UnidadesRestantes { get; set; }
    public string Direccion { get; set; } = string.Empty;
    public double Longitud { get; set; }
    public double Latitud { get; set; }
    public DateTime FechaHoraInicio { get; set; }
    public DateTime FechaHoraFin { get; set; }
    public CategoriaHorariaEvento CategoriaHoraria { get; set; }
    public List<Alergia> Alergias { get; set; } = new();
}
