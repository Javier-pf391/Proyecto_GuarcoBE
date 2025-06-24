using AccesoDatos.Interfaces;
using AccesoDatos;
using Negocio.Interfaces;
using Negocio;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using System;
using Entidades.SqlServer;
using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=Proyecto_Guarco.db"));


// Registrar servicios de acceso a datos y lógica de negocio
builder.Services.AddTransient<IDocumentos_GuarcoAD, Documentos_GuarcoAD>();
builder.Services.AddTransient<IDocumentos_GuarcoLN, Documentos_GuarcoLN>();

// Agregar servicios para controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate(); 
}

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
