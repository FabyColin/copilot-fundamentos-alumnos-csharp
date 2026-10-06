namespace Ejercicio1;

public record ProductoInventario(string Sku, string Nombre, int Stock, decimal Precio, DateOnly Caducidad);

public record ReporteInventario(int Productos, int Unidades, decimal ValorTotal);

/// <summary>
/// Cierre del Ejercicio 1: inventario de la farmacia.
///
/// Implementa cada método usando SOLO autocompletado (sin chat): borra el <c>throw</c> y deja
/// que Copilot proponga el cuerpo. Requisitos en docs/ejercicios/ej1-autocompletado.md.
/// Valida con: dotnet test ejercicios/ej1-autocompletado
/// </summary>
public class Inventario
{
    public void Agregar(ProductoInventario producto) => throw new NotImplementedException();

    public void Eliminar(string sku) => throw new NotImplementedException();

    public IReadOnlyList<ProductoInventario> Buscar(string texto) => throw new NotImplementedException();

    public IReadOnlyList<ProductoInventario> StockBajo(int umbral) => throw new NotImplementedException();

    public IReadOnlyList<ProductoInventario> ProximosACaducar(int dias, DateOnly? hoy = null) =>
        throw new NotImplementedException();

    public ReporteInventario Reporte() => throw new NotImplementedException();
}
