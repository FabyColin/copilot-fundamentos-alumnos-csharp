namespace Farmacia.Api;

/// <summary>Almacén en memoria: los datos se reinician al arrancar la aplicación.</summary>
public class RepositorioProductos
{
    public static readonly IReadOnlyList<string> Categorias =
    [
        "Analgésicos y antiinflamatorios",
        "Antibióticos",
        "Alergias y respiratorio",
        "Aparato digestivo",
        "Vitaminas y suplementos",
        "Cuidado personal e higiene",
        "Material de curación",
        "Bebé y maternidad",
        "Dispositivos médicos",
    ];

    private readonly List<Producto> _productos =
    [
        Nuevo("p-001", "Paracetamol 500 mg", "Caja con 20 tabletas", 45.00m, "Analgésicos y antiinflamatorios", 120, false),
        Nuevo("p-002", "Amoxicilina 500 mg", "Caja con 12 cápsulas", 129.50m, "Antibióticos", 30, true),
        Nuevo("p-003", "Vitamina C 1 g", "Tubo con 10 tabletas efervescentes", 89.00m, "Vitaminas y suplementos", 60, false),
        Nuevo("p-004", "Gel antibacterial 500 ml", "Frasco con dosificador", 62.00m, "Cuidado personal e higiene", 80, false),
        Nuevo("p-005", "Termómetro digital", "Lectura en 10 segundos", 149.00m, "Dispositivos médicos", 25, false),
        Nuevo("p-006", "Loratadina 10 mg", "Caja con 10 tabletas", 58.00m, "Alergias y respiratorio", 40, false),
    ];

    private readonly object _candado = new();

    private static Producto Nuevo(string id, string nombre, string descripcion, decimal precio, string categoria, int stock, bool requiereReceta) =>
        new()
        {
            Id = id,
            Nombre = nombre,
            Descripcion = descripcion,
            Precio = precio,
            Categoria = categoria,
            Stock = stock,
            RequiereReceta = requiereReceta,
        };

    public IReadOnlyList<Producto> Listar(string? categoria = null)
    {
        lock (_candado)
        {
            return string.IsNullOrEmpty(categoria)
                ? _productos.ToList()
                : _productos.Where(p => p.Categoria == categoria).ToList();
        }
    }

    public Producto? Obtener(string? id)
    {
        lock (_candado)
        {
            return _productos.FirstOrDefault(p => p.Id == id);
        }
    }

    public Producto Agregar(string nombre, string descripcion, decimal precio, string categoria, int stock, bool requiereReceta)
    {
        var producto = Nuevo(Guid.NewGuid().ToString(), nombre, descripcion, precio, categoria, stock, requiereReceta);
        lock (_candado)
        {
            _productos.Add(producto);
        }
        return producto;
    }

    public bool Eliminar(string id)
    {
        lock (_candado)
        {
            return _productos.RemoveAll(p => p.Id == id) > 0;
        }
    }
}
