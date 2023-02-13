using EF_NET.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_NET;

class TareasContext:DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) :base(options)
    {
        
    }
}