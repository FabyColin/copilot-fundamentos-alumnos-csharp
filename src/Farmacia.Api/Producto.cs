namespace Farmacia.Api;

/// <summary>Producto de la farmacia. Todos los datos del curso son ficticios.</summary>
public class Producto
{
    public required string Id { get; init; }
    public required string Nombre { get; set; }
    public string Descripcion { get; set; } = "";
    public decimal Precio { get; set; }
    public required string Categoria { get; set; }
    public int Stock { get; set; }

    /// <summary>Verdadero para medicamentos que se venden solo con receta (por ejemplo, antibióticos).</summary>
    public bool RequiereReceta { get; set; }
}
