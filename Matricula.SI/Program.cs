using Matricula.BL.Repositorios;
using Matricula.DA.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var enviroment = builder.Environment.IsDevelopment() ? "Local" : "Produccion";
var cadenaDeConeccion = builder.Configuration.GetConnectionString(enviroment);
builder.Services.AddDbContext<DBContexto>(x => x.UseSqlServer(cadenaDeConeccion));

// Servicios
builder.Services.AddScoped<IrepositorioDeEstudiantes, RepositorioDeEstudiantes>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
