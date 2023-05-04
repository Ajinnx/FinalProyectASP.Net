namespace FinalProject.Models;

public sealed class UsuarioProveedor
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string Dni { get; set; } = string.Empty;
    public string Usuario { get; set; } = string.Empty;
    public string Contrasena { get; set; } = string.Empty;
    public string DireccionDomicilio { get; set; } = string.Empty;
    public string CorreoElectronico { get; set; } = string.Empty;
    public int Puntuacion { get; set; }
}
