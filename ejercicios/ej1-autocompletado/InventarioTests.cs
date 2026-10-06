namespace Ejercicio1;

/// <summary>Pruebas de validación del cierre del Ejercicio 1 (vienen incluidas; no las modifiques).</summary>
public class InventarioTests
{
    private static readonly DateOnly Hoy = new(2026, 10, 1);

    private static Inventario NuevoInventario()
    {
        var inv = new Inventario();
        inv.Agregar(new("A1", "Paracetamol 500 mg", 120, 45.00m, new DateOnly(2027, 6, 30)));
        inv.Agregar(new("B2", "Amoxicilina 500 mg", 3, 129.50m, new DateOnly(2026, 11, 15)));
        inv.Agregar(new("C3", "Vitamina C 1 g", 0, 89.00m, new DateOnly(2026, 10, 20)));
        inv.Agregar(new("D4", "Jarabe para la tos", 5, 70.00m, new DateOnly(2026, 9, 15)));
        return inv;
    }

    [Fact]
    public void Agregar_un_sku_duplicado_lanza_ArgumentException()
    {
        var inv = NuevoInventario();

        Assert.Throws<ArgumentException>(() => inv.Agregar(new("A1", "Otro", 1, 1m, Hoy)));
    }

    [Fact]
    public void Eliminar_quita_el_producto()
    {
        var inv = NuevoInventario();

        inv.Eliminar("A1");

        Assert.Empty(inv.Buscar("paracetamol"));
    }

    [Fact]
    public void Eliminar_un_sku_inexistente_lanza_KeyNotFoundException()
    {
        var inv = NuevoInventario();

        Assert.Throws<KeyNotFoundException>(() => inv.Eliminar("ZZZ"));
    }

    [Fact]
    public void Buscar_ignora_mayusculas_y_minusculas()
    {
        var inv = NuevoInventario();

        Assert.Equal(["C3"], inv.Buscar("VITAMINA").Select(p => p.Sku));
    }

    [Fact]
    public void StockBajo_devuelve_los_productos_bajo_el_umbral()
    {
        var inv = NuevoInventario();

        Assert.Equal(["B2", "C3"], inv.StockBajo(5).Select(p => p.Sku).Order());
    }

    [Fact]
    public void ProximosACaducar_incluye_vencidos_y_ordena_por_fecha()
    {
        var inv = NuevoInventario();

        // Límite: 1-oct + 60 días = 30-nov. D4 ya venció; C3 y B2 vencen dentro del plazo; A1 no.
        Assert.Equal(["D4", "C3", "B2"], inv.ProximosACaducar(60, Hoy).Select(p => p.Sku));
    }

    [Fact]
    public void ProximosACaducar_con_un_plazo_corto()
    {
        var inv = NuevoInventario();

        Assert.Equal(["D4", "C3"], inv.ProximosACaducar(30, Hoy).Select(p => p.Sku));
    }

    [Fact]
    public void Reporte_incluye_totales_y_valor_del_inventario()
    {
        var inv = NuevoInventario();

        var reporte = inv.Reporte();

        Assert.Equal(4, reporte.Productos);
        Assert.Equal(128, reporte.Unidades);
        Assert.Equal(120 * 45.00m + 3 * 129.50m + 5 * 70.00m, reporte.ValorTotal);
    }
}
