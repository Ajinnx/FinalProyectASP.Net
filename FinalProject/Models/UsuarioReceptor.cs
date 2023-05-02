namespace FinalProject.Models;

public sealed class UsuarioReceptor
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellidos { get; set; } = string.Empty;
    public string Dni { get; set; } = string.Empty;
    public string Contrasena { get; set; } = string.Empty;

    /// <summary>
    /// Propiedad de navegación (Entity Framework)
    /// </summary>
    public List<Evento> Eventos { get; set; } = new();
}
