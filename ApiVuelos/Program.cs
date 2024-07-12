using ApiVuelos.Automappers;
using ApiVuelos.DTOs;
using ApiVuelos.Models;
using ApiVuelos.Repository;
using ApiVuelos.Services;
using ApiVuelos.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Interfaz de Servicios
builder.Services.AddKeyedScoped<ICommonService<VueloDto, CrearVueloDto, ModificarVueloDto>, VueloService>("FlyService");

//Repository
builder.Services.AddScoped<IRepository<Vuelo>, VueloRepository>();

//EF
builder.Services.AddDbContext<VuelosDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

//Mappers
builder.Services.AddAutoMapper(typeof(MappingProfile));

//FluentValidation
builder.Services.AddScoped<IValidator<CrearVueloDto>, CrearVuelosValidator>();
builder.Services.AddScoped<IValidator<ModificarVueloDto>,  ModificarVuelosValidator>();

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
