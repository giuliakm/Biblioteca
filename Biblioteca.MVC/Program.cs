
using Biblioteca.Consumer;
using Biblioteca.Modelos;
using Microsoft.EntityFrameworkCore;

CRUD<Autor>.Endpoint = "https://localhost:7040/api/Autores";
CRUD<Editorial>.Endpoint = "https://localhost:7040/api/Editoriales";
CRUD<Genero>.Endpoint = "https://localhost:7040/api/Generos";
CRUD<Libro>.Endpoint = "https://localhost:7040/api/Libros";


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BibliotecaAPIContext") ?? throw new InvalidOperationException("Connection string 'BibliotecaAPIContext' not found.");

builder.Services.AddDbContext<BibliotecaAPIContext>(options => options.UseNpgsql(connectionString));


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
