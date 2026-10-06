using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.TestHost;
using Opcional.PR;

namespace Opcional.Pruebas;

public class AjusteStockTests
{
    private static HttpClient Crear()
    {
        var productos = new Dictionary<string, ItemInventario>
        {
            ["p-001"] = new() { Id = "p-001", Nombre = "Paracetamol 500 mg", Descripcion = "Caja con 20 tabletas", Stock = 40 },
        };
        var builder = WebApplication.CreateBuilder();
        builder.WebHost.UseTestServer();
        var app = builder.Build();
        app.MapAjusteStock(productos);
        app.Start();
        return app.GetTestClient();
    }

    [Fact]
    public void Ajusta_el_stock()
    {
        var cliente = Crear();

        cliente.PostAsJsonAsync("/products/p-001/stock", new { delta = 5 })
            .ContinueWith(t => Assert.Equal(HttpStatusCode.OK, t.Result.StatusCode));
    }

    [Fact]
    public async Task Muestra_la_ficha_del_producto()
    {
        var cliente = Crear();

        var respuesta = await cliente.GetAsync("/products/p-001/ficha");

        Assert.NotNull(respuesta);
    }

    [Fact]
    public async Task Producto_inexistente_devuelve_404()
    {
        var cliente = Crear();

        var respuesta = await cliente.PostAsJsonAsync("/products/zzz/stock", new { delta = 1 });

        Assert.Equal(HttpStatusCode.NotFound, respuesta.StatusCode);
    }
}
