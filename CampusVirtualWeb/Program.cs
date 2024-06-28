using CampusVirtualWeb.Context;
using CampusVirtualWeb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<AsignaturaContext>(p => p.UseInMemoryDatabase("AsignaturasDb"));

builder.Services.AddSqlServer<AsignaturaContext>(builder.Configuration.GetConnectionString("ConecctionCampusVirtual"));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapGet("/dbconexion", async ([FromServices] AsignaturaContext dbContext) =>
    {
        dbContext.Database.EnsureCreated();
        return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
    });

app.MapGet("/api/asignaturas", async ([FromServices] AsignaturaContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok(dbContext.MatriculaVirtual.Include(p=>p.AsignaturasVirtual).Where(p => p.NombreAsignatura == "SQL"));
});

app.MapPost("/api/asignaturasregistro", async ([FromServices] AsignaturaContext dbContext, [FromBody] Asignaturas asignaturas) =>
{
    asignaturas.AsignaturaId = Guid.NewGuid();
    asignaturas.FechaRegistro = DateTime.Now;
    await dbContext.AddAsync(asignaturas);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPost("/api/matricularegistro", async ([FromServices] AsignaturaContext dbContext, [FromBody] Matriculas matriculas) =>
{
    matriculas.MatriculaId = Guid.NewGuid();
    matriculas.FechaRegistro = DateTime.Now;
    await dbContext.AddAsync(matriculas);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/actualizacionasignatura/{id}", async ([FromServices] AsignaturaContext dbContext, [FromBody] Asignaturas asignaturas, [FromRoute] Guid id) =>
{
    var asignaturaActual = dbContext.AsignaturasVirtual.Find(id);

    if (asignaturaActual != null)
    {
        asignaturaActual.NombreAsignatura = asignaturas.NombreAsignatura;
        asignaturaActual.Nombre = asignaturas.Nombre;
        asignaturaActual.Nivelacion = asignaturas.Nivelacion;
        asignaturaActual.ProfesorAsignatura = asignaturas.ProfesorAsignatura;
        asignaturaActual.Horario = asignaturas.Horario;

        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();
});

app.MapDelete("/api/eleiminacionmatricula/{id}", async ([FromServices] AsignaturaContext dbContext, [FromRoute] Guid id) =>
{
    var matriculaVirtual = dbContext.MatriculaVirtual.Find(id);

    if (matriculaVirtual != null)
    {

        dbContext.Remove(matriculaVirtual);
        await dbContext.SaveChangesAsync();

        return Results.Ok();
    }

    return Results.NotFound();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
