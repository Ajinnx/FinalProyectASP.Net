using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Contexts;

/// <summary>
/// Clase que permite conectarse a la base de datos y hacer uso de sus entidades.
/// </summary>
public sealed class AppDbContext : DbContext
{
    public DbSet<UsuarioReceptor> UsuariosReceptores { get; set; }
    public DbSet<UsuarioProveedor> UsuariosProveedores { get; set; }
    public DbSet<UsuarioEmpresa> UsuariosEmpresas { get; set; }
    public DbSet<UsuarioOng> UsuariosOngs { get; set; }
    public DbSet<Evento> Eventos { get; set; }
    public DbSet<Alergia> Alergias { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        
    }
}
