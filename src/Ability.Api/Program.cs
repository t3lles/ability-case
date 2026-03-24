using Ability.Api.Data;
using Ability.Api.Models;
using Ability.Api.Repositories;
using Ability.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configuração do Swagger com prefixo global para evitar conflito com a pasta Models
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new global::Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Ability Ticket API",
        Version = "v1",
        Description = "Internal Support Ticket System"
    });
});

// 2. Configure Database (SQL Server)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Register Repository (Dependency Injection)
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

// 4. Configure CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// AUTO-MIGRATION
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate();
        Console.WriteLine("Database and Migrations applied successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro ao aplicar migrations: {ex.Message}");
    }
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ability API V1");
    c.RoutePrefix = string.Empty; // Swagger na raiz (http://localhost:5000)
});

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();