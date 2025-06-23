using AccesoDatos;
using Negocio.Interfaces;
using Negocio;
using Microsoft.EntityFrameworkCore;
using AccesoDatos.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Registrar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQLServer")));

// Registrar servicios
builder.Services.AddTransient<IDocumentos_GuarcoAD, Documentos_GuarcoAD>();
builder.Services.AddTransient<IDocumentos_GuarcoLN, Documentos_GuarcoLN>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// ?? Endpoint de prueba para la conexión a la BD
app.MapGet("/can-connect", async (AppDbContext db) =>
{
    return await db.Database.CanConnectAsync()
        ? Results.Ok("¡Conexión exitosa! ??")
        : Results.Problem("No se pudo conectar", statusCode: 503);
});

app.MapControllers();

app.Run();
