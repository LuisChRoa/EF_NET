using EF_NET;
using EF_NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB")); //Conexion para BD en memoria
//builder.Services.AddSqlServer<TareasContext>(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=TareasDbDes; user id=testChaparro; password=12345");
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet ("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();
    return Results.Ok($"ok ok" );
});

app.MapGet("/api/tareas",async ([FromServices] TareasContext dbContext) => 
{
    return Results.Ok(dbContext.Tareas.Include(i => i.Categoria).Where(w => w.PrioridadTarea == Prioridad.Media));
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea)=>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreacion = DateTime.Now;
    await dbContext.AddAsync(tarea);
    //await dbContext.Tareas.AddAsync(tarea);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.Run();
