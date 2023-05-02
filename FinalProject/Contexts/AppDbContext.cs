using FinalProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Contexts;

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
