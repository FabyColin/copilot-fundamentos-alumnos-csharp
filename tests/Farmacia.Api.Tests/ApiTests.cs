using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Farmacia.Api.Tests;

/// <summary>Pruebas mínimas de la base. En el Ejercicio 4 el alumno las amplía con /tests.</summary>
public class ApiTests
{
    // Cada prueba arranca su propia aplicación: los datos viven en memoria y no se comparten entre pruebas.
    private static HttpClient NuevoCliente() => new WebApplicationFactory<Program>().CreateClient();

    [Fact]
    public async Task Lista_los_productos()
    {
        var respuesta = await NuevoCliente().GetAsync("/products");

        Assert.Equal(HttpStatusCode.OK, respuesta.StatusCode);
        var productos = await respuesta.Content.ReadFromJsonAsync<JsonElement>();
        Assert.Equal(6, productos.GetArrayLength());
    }

    [Fact]
    public async Task Producto_inexistente_devuelve_404()
    {
        var respuesta = await NuevoCliente().GetAsync("/products/no-existe");

        Assert.Equal(HttpStatusCode.NotFound, respuesta.StatusCode);
    }
}
