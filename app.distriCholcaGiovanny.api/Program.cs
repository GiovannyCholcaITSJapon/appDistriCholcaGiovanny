using System;
using app.distriCholcaGiovanny.common.EventMQ;
using app.distriCholcaGiovanny.dataAccess.context;
using app.distriCholcaGiovanny.dataAccess.repositories;
using app.distriCholcaGiovanny.services.EventMQ;
using app.distriCholcaGiovanny.services.Implementations;
using app.distriCholcaGiovanny.services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//LA CADENA DE CONEXION ESTA EN EL appsettings.json
//CON EL SIGUIENTA LINEA OBTENEMOS LA CADENA DE CONEXION A SQL SERVER
var conSqlServer = builder.Configuration.GetConnectionString("BDDSqlServer")!;
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(conSqlServer);
    options.LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging();
});

// Leer la configuración de RabbitMQ desde el appsettings.json y lo setea en la clase RabbitMQSettings
builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("rabbitmq"));


//declarar servicio y repositorios
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

builder.Services.AddSingleton<IRabbitMQService, RabbitMQService>();



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
