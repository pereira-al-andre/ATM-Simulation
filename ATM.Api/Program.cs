using ATM.Application;
using ATM.Domain;
using ATM.Infrastructure;
using ATM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ATM Machine Sumulation",
        Version = "v1",
        Contact = new OpenApiContact()
        {
            Name = "André Pereira",
            Email = "pereira.al.andre@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/almeidaandrep/")
        },
        Description = "Este projeto tem por objetivo trabalhar o comportamento de um caixa eletrônico."
    });

    // Adiciona informações de comentário dos métodos do controller
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var conn = builder.Configuration.GetConnectionString("SqlDbContext");

builder.Services.AddDbContext<SqlDBContext>(o => o.UseSqlServer(conn));

builder.Services.InfrastructureDependencyInjection();
builder.Services.DomainDependencyInjection();
builder.Services.ApplicationDependencyInjection();

var app = builder.Build();

using (var serviceScope = app.Services.CreateScope())
{
    try
    {
        var dbContext = serviceScope.ServiceProvider.GetRequiredService<SqlDBContext>();
        dbContext.Database.Migrate();
    }
    catch (Exception)
    {
        throw new Exception("Erro ao executar migrações automaticamente. Esse erro pode acontecer caso a aplicação inicie antes do container terminar a inicialização do banco de dados.");
    }
   
}

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
