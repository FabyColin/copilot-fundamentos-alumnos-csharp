namespace Opcional.PR;

public class ItemInventario
{
    public required string Id { get; init; }
    public required string Nombre { get; set; }
    public string Descripcion { get; set; } = "";
    public int Stock { get; set; }
}

public record AjusteRequest(int Delta);

/// <summary>
/// Ajuste de stock y ficha de producto.
///
/// Agrega dos rutas a la API de la farmacia:
///   POST /products/{id}/stock   suma o resta unidades al stock de un producto
///   GET  /products/{id}/ficha   muestra una ficha HTML del producto
/// </summary>
public static class AjusteStockEndpoints
{
    public static IEndpointRouteBuilder MapAjusteStock(
        this IEndpointRouteBuilder app,
        Dictionary<string, ItemInventario> productos)
    {
        app.MapPost("/products/{id}/stock", (string id, AjusteRequest datos) =>
        {
            if (!productos.TryGetValue(id, out var producto))
            {
                return Results.NotFound(new { error = "Producto no encontrado" });
            }

            producto.Stock += datos.Delta;
            return Results.Ok(producto);
        });

        app.MapGet("/products/{id}/ficha", (string id) =>
        {
            if (!productos.TryGetValue(id, out var producto))
            {
                return Results.Content("Producto no encontrado", "text/html", statusCode: 404);
            }

            return Results.Content(
                $"<h1>{producto.Nombre}</h1>" +
                $"<p>{producto.Descripcion}</p>" +
                $"<p>Stock disponible: {producto.Stock}</p>",
                "text/html");
        });

        return app;
    }
}
