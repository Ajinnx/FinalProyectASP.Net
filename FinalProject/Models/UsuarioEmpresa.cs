namespace FinalProject.Models;

public sealed class UsuarioEmpresa
{
    public int Id { get; set; }
    public string NombreEmpresa { get; set; } = string.Empty;
    public string Cif { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string TelefonoDirector { get; set; } = string.Empty;
    public string CorreoElectronicoDirector { get; set; } = string.Empty;
    public int Puntuacion { get; set; }
}
