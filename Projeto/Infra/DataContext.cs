using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Models;

namespace Projeto.Infra;

public class DataContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }
}