namespace FinalProject.Models;

public sealed class Alergia
{
    public int Id { get; set; }

    /// <summary>
    /// Un nombre fácilmente reconocible que represente una alergia.
    /// </summary>
    public string Nombre { get; set; } = string.Empty;

    /// <summary>
    /// Propiedad de navegación (Entity Framework)
    /// </summary>
    public List<Evento> Eventos { get; set; } = new();
}
