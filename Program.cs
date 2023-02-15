using EF_NET;
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

app.Run();
