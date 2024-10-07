using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using OdontoPrev.Application.Interfaces;
using OdontoPrev.Application.Services;
using OdontoPrev.Domain.Interfaces;
using OdontoPrev.Infrastructure.Persistence;
using OdontoPrev.Infrastructure.Repositories;
using OdontoPrev.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner

// Configurar DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar Reposit�rios
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();
// Adicione os demais reposit�rios...

// Registrar Servi�os de Aplica��o
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<ITarefaService, TarefaService>();
// Adicione os demais servi�os...

// Registrar Servi�os de Infraestrutura
builder.Services.AddScoped<IFileStorageService, FileStorageService>();
builder.Services.AddHttpClient<FotoValidationService>(client =>
{
    client.BaseAddress = new Uri("https://api.validadorfotos.com/");
    // Configurar headers, autentica��o, etc.
});

// Adicionar Controllers
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de requisi��es HTTP

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(); // Para servir as fotos armazenadas

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

