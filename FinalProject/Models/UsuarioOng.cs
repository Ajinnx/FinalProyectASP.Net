namespace FinalProject.Models;

public sealed class UsuarioOng
{
    public int Id { get; set; }
    public string NombreOng { get; set; } = string.Empty;
    public string Cif { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string Usuario { get; set; } = string.Empty;
    public string Contrasena { get; set; } = string.Empty;
    public string TelefonoDirector { get; set; } = string.Empty;
    public string CorreoElectronicoDirector { get; set; } = string.Empty;
    public int Puntuacion { get; set; }
}
