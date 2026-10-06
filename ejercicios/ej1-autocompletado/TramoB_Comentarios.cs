namespace Ejercicio1;

public record ProductoCatalogo(string Nombre, string Categoria, decimal Precio, int Stock);

/// <summary>
/// Tramo B: desarrollo guiado por comentarios.
///
/// Instrucciones: debajo de cada comentario escribe la firma del método y deja que Copilot complete.
/// Si la sugerencia no es lo que querías, mejora el comentario (más preciso) en vez de editar el código.
/// </summary>
public static class TramoB
{
    public static readonly List<ProductoCatalogo> Productos =
    [
        new("Paracetamol 500 mg", "Analgésicos y antiinflamatorios", 45.00m, 120),
        new("Amoxicilina 500 mg", "Antibióticos", 129.50m, 30),
        new("Vitamina C 1 g", "Vitaminas y suplementos", 89.00m, 0),
        new("Gel antibacterial 500 ml", "Cuidado personal e higiene", 62.00m, 80),
    ];

    // Devuelve los productos de una categoría, ignorando mayúsculas y minúsculas


    // Ordena una lista de productos por precio; el parámetro `descendente` invierte el orden


    // Devuelve los productos con stock mayor a cero y precio menor o igual a un máximo dado


    // Agrupa los productos por categoría y devuelve un diccionario { categoría: [nombres] }
}
