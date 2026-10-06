namespace Ejercicio1;

public record ProductoSimple(string Nombre, decimal Precio);

/// <summary>
/// Tramo C: Next Edit Suggestions (NES).
///
/// Instrucciones: activa NES (<c>github.copilot.nextEditSuggestions.enabled</c>).
/// Renombra la propiedad <c>Nombre</c> a <c>NombreComercial</c> SOLO en el record <c>ProductoSimple</c>
/// y observa cómo Copilot sugiere el resto de las ediciones relacionadas.
/// Navega entre ellas con Tab y acéptalas una por una, revisando cada una.
/// </summary>
public static class TramoC
{
    public static ProductoSimple CrearProducto(string nombre, decimal precio) =>
        new(Nombre: nombre, Precio: precio);

    public static string MostrarProducto(ProductoSimple producto) =>
        $"{producto.Nombre} - ${producto.Precio:N2}";

    public static List<ProductoSimple> BuscarPorNombre(List<ProductoSimple> productos, string texto) =>
        productos.Where(p => p.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();

    public static List<string> ExportarNombres(List<ProductoSimple> productos) =>
        productos.Select(p => p.Nombre).ToList();

    public static List<ProductoSimple> OrdenarAlfabeticamente(List<ProductoSimple> productos) =>
        productos.OrderBy(p => p.Nombre, StringComparer.CurrentCultureIgnoreCase).ToList();
}
