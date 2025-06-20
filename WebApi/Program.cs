using AccesoDatos.Interfaces;
using AccesoDatos;
using Negocio.Interfaces;
using Negocio;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

var builder = WebApplication.CreateBuilder(args);


// Configurar DbContext para usar SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("ConexionSQLite"))
);

// Registrar servicios de acceso a datos y lógica de negocio
builder.Services.AddTransient<IDocumentos_GuarcoAD, Documentos_GuarcoAD>();
builder.Services.AddTransient<IDocumentos_GuarcoLN, Documentos_GuarcoLN>();

// Agregar servicios para controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de la aplicación
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
