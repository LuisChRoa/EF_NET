using EF_NET.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_NET;

class TareasContext:DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) :base(options){}

    // Crear Modelo BD por Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(cat =>
        {
            cat.ToTable("tb_categoria");
            cat.HasKey(c => c.CategoriaId);
            cat.Property(c => c.Nombre).IsRequired().HasMaxLength(150);
            cat.Property(c => c.Descripcion);
        });

        modelBuilder.Entity<Tarea>(tar=>{
            tar.ToTable("pr_tarea");
            tar.HasKey(c => c.TareaId);
            tar.HasOne(c => c.Categoria).WithMany(c => c.Tareas).HasForeignKey(c => c.CategoriaId);
            tar.Property(c => c.Titulo).IsRequired().HasMaxLength(200);
            tar.Property(c => c.Descripcion);
            tar.Property(c => c.PrioridadTarea);
            tar.Property(c => c.FechaCreacion);
            tar.Ignore(c => c.Resumen);
        });
    }
}