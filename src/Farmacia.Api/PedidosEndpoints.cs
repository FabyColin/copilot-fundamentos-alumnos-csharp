namespace Farmacia.Api;

public record ItemPedido(string? ProductId, int? Cantidad);

public record PedidoRequest(List<ItemPedido>? Items);

public record LineaPedido(string ProductId, int Cantidad, decimal Subtotal);

public static class PedidosEndpoints
{
    /// <summary>POST /orders calcula el total de un pedido: { "items": [{ "product_id": "...", "cantidad": 2 }] }.</summary>
    public static IEndpointRouteBuilder MapPedidos(this IEndpointRouteBuilder app)
    {
        app.MapPost("/orders", (RepositorioProductos repo, PedidoRequest? pedido) =>
        {
            var items = pedido?.Items;
            if (items is null || items.Count == 0)
            {
                return Results.BadRequest(new { error = "El pedido no tiene items" });
            }

            var detalle = new List<LineaPedido>();
            decimal total = 0;
            foreach (var item in items)
            {
                var producto = repo.Obtener(item.ProductId);
                if (producto is null)
                {
                    return Results.NotFound(new { error = $"Producto no encontrado: {item.ProductId}" });
                }

                var cantidad = item.Cantidad ?? 1;
                var subtotal = producto.Precio * cantidad;
                total += subtotal;
                detalle.Add(new LineaPedido(producto.Id, cantidad, subtotal));
            }

            return Results.Json(
                new { items = detalle, total = Math.Round(total, 2) },
                statusCode: StatusCodes.Status201Created);
        });

        return app;
    }
}
