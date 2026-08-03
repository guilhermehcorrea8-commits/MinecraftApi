using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Web_Api_29_07_Mine.Context;
using Web_Api_29_07_Mine.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// SQL Server
builder.Services.AddDbContext<MinecraftContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// HttpClient Services
builder.Services.AddHttpClient<MojangService>();
builder.Services.AddHttpClient<WikiService>();

// Singleton Services
builder.Services.AddSingleton<SkinService>();

// Swagger / OpenAPI (Configuração Única)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minecraft API",
        Version = "v1.0",
        Description = "API desenvolvida em ASP.NET Core 8 para gerenciamento de jogadores, mundos, itens, mobs, blocos, biomas e encantamentos do Minecraft.",
        Contact = new OpenApiContact
        {
            Name = "Guilherme Hofman",
            Email = "guilherme@email.com"
        },
        License = new OpenApiLicense
        {
            Name = "MIT"
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minecraft API v1");
    c.DocumentTitle = "Minecraft API";
    c.RoutePrefix = "";
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();