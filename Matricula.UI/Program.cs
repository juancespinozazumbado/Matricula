using Matricula.BL.Repositorios;
using Matricula.DA.DataBase;
using Matricula.UI.Models;
using Matricula.UI.Servicios;
using Matricula.UI.Servicios.Iservicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var enviroment = builder.Environment.IsDevelopment() ? "Local" : "Produccion";

ConfiguracionApi.API_URL = builder.Configuration[$"UrlServicio:{enviroment}"];

// Servicios
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddTransient<IservicioRest,ServicioRest>();
builder.Services.AddTransient<IservicioDeEstudiantes, ServicioDeEstudiantes>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Estudiantes}/{action=Index}/{id?}");

app.Run();
