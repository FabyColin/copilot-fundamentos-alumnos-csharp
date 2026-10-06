namespace Farmacia.Api;

public record CrearProductoRequest(
    string? Nombre,
    string? Descripcion,
    decimal? Precio,
    string? Categoria,
    int? Stock,
    bool? RequiereReceta);

public record ActualizarProductoRequest(
    string? Nombre,
    string? Descripcion,
    decimal? Precio,
    string? Categoria,
    int? Stock,
    bool? RequiereReceta);

public static class ProductosEndpoints
{
    public static IEndpointRouteBuilder MapProductos(this IEndpointRouteBuilder app)
    {
        app.MapGet("/products", (RepositorioProductos repo, string? categoria) =>
            Results.Ok(repo.Listar(categoria)));

        app.MapGet("/products/{id}", (RepositorioProductos repo, string id) =>
            repo.Obtener(id) is { } producto ? Results.Ok(producto) : NoEncontrado());

        app.MapPost("/products", (RepositorioProductos repo, CrearProductoRequest? datos) =>
        {
            if (datos?.Nombre is null)
            {
                return Results.BadRequest(new { error = "El campo 'nombre' es obligatorio" });
            }

            var producto = repo.Agregar(
                datos.Nombre,
                datos.Descripcion ?? "",
                datos.Precio ?? 0,
                datos.Categoria ?? "Cuidado personal e higiene",
                datos.Stock ?? 0,
                datos.RequiereReceta ?? false);
            return Results.Json(producto, statusCode: StatusCodes.Status201Created);
        });

        app.MapPut("/products/{id}", (RepositorioProductos repo, string id, ActualizarProductoRequest? datos) =>
        {
            var producto = repo.Obtener(id);
            if (producto is null)
            {
                return NoEncontrado();
            }

            if (datos is not null)
            {
                producto.Nombre = datos.Nombre ?? producto.Nombre;
                producto.Descripcion = datos.Descripcion ?? producto.Descripcion;
                producto.Precio = datos.Precio ?? producto.Precio;
                producto.Categoria = datos.Categoria ?? producto.Categoria;
                producto.Stock = datos.Stock ?? producto.Stock;
                producto.RequiereReceta = datos.RequiereReceta ?? producto.RequiereReceta;
            }
            return Results.Ok(producto);
        });

        app.MapDelete("/products/{id}", (RepositorioProductos repo, string id) =>
            repo.Eliminar(id) ? Results.NoContent() : NoEncontrado());

        return app;
    }

    private static IResult NoEncontrado() =>
        Results.NotFound(new { error = "Producto no encontrado" });
}
