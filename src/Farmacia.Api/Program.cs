using System.Text.Json;
using System.Text.Json.Serialization;
using Farmacia.Api;

var builder = WebApplication.CreateBuilder(args);

// El contrato JSON es el mismo en las tres pistas: nombres en snake_case (requiere_receta, product_id...)
// y números estrictos (un texto como "2" no se acepta donde se espera un entero).
builder.Services.ConfigureHttpJsonOptions(opciones =>
{
    opciones.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
    opciones.SerializerOptions.NumberHandling = JsonNumberHandling.Strict;
});

builder.Services.AddSingleton<RepositorioProductos>();
builder.Services.AddRazorPages();

var app = builder.Build();

app.MapProductos();
app.MapPedidos();
app.MapRazorPages();

app.Run();

// Necesario para que las pruebas de integración (WebApplicationFactory<Program>) vean el punto de entrada.
public partial class Program;
