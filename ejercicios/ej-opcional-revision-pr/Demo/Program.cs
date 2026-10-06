// Para probar el PR en tu máquina (no forma parte del PR).
//
//   dotnet run --project ejercicios/ej-opcional-revision-pr/Demo     # http://localhost:5001
//
// Reproduce lo que ya existe en el proyecto: una farmacia con productos en memoria y
// POST /products para crear nuevos. Sobre eso se montan las rutas del PR.
using Opcional.PR;

var productos = new Dictionary<string, ItemInventario>
{
    ["p-001"] = new() { Id = "p-001", Nombre = "Paracetamol 500 mg", Descripcion = "Caja con 20 tabletas", Stock = 40 },
    ["p-002"] = new() { Id = "p-002", Nombre = "Loratadina 10 mg", Descripcion = "Caja con 10 tabletas", Stock = 12 },
};

var app = WebApplication.CreateBuilder(args).Build();

app.MapPost("/products", (CrearItem datos) =>
{
    var id = Guid.NewGuid().ToString();
    var producto = new ItemInventario
    {
        Id = id,
        Nombre = datos.Nombre ?? "Sin nombre",
        Descripcion = datos.Descripcion ?? "",
        Stock = datos.Stock ?? 0,
    };
    productos[id] = producto;
    return Results.Created($"/products/{id}", producto);
});

app.MapAjusteStock(productos);

app.Run("http://localhost:5001");

record CrearItem(string? Nombre, string? Descripcion, int? Stock);
