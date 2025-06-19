using AccesoDatos.Interfaces;
using AccesoDatos;
using Negocio.Interfaces;
using Negocio;
var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.AddTransient<IDocumentos_GuarcoAD, Documentos_GuarcoAD>();
builder.Services.AddTransient<IDocumentos_GuarcoLN, Documentos_GuarcoLN>();

builder.Services.AddSingleton(builder.Configuration.GetSection("ConnectionStrings"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
