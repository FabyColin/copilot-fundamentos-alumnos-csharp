# Ejercicio 1: Autocompletado (C#)

**Módulo:** [2. Autocompletado](../modulos/02-autocompletado.md) · **Tiempo:** 30 min (3 tramos aislados) + 50 min (ejercicio completo)
**Carpeta:** `ejercicios/ej1-autocompletado/`

> **Regla del ejercicio**
>
> Nada de chat. Solo autocompletado, comentarios y NES.

## Tramo A: ghost text (10 min)

**Archivo:** `TramoA_GhostText.cs`

1. En cada método, borra la línea `throw new NotImplementedException();`, deja solo la firma y escribe de nuevo el cuerpo con ayuda del ghost text.
2. Observa la sugerencia. Practica: `Tab` (aceptar), `Esc` (descartar), `Alt+]` (otra alternativa), `Ctrl+→` (aceptar una palabra).
3. Para `EsEmailValido`, revisa con cuidado: ¿la sugerencia valida bien `a@b`, `a@@b.com`, una cadena vacía o `null`?

**Entregable:** los 4 métodos completos y una nota con **una sugerencia que rechazaste** y por qué.

## Tramo B: guiado por comentarios (10 min)

**Archivo:** `TramoB_Comentarios.cs`

1. Bajo cada comentario, escribe la firma del método (dentro de la clase `TramoB`) y deja que Copilot complete.
2. Si la sugerencia no es lo que querías, **mejora el comentario** (no el código) y vuelve a intentar.
3. Comprueba cada método con un `[Fact]` temporal en un archivo nuevo (por ejemplo `MisPruebas.cs`) usando la lista `TramoB.Productos`.

**Entregable:** 4 métodos funcionando. Anota cuántos comentarios tuviste que reescribir.

## Tramo C: Next Edit Suggestions (10 min)

**Archivo:** `TramoC_Nes.cs`

1. Confirma que `github.copilot.nextEditSuggestions.enabled` está activo.
2. En el `record ProductoSimple` cambia la propiedad `Nombre` por `NombreComercial`.
3. Sigue las sugerencias de Copilot con `Tab` y **revisa cada una** antes de aceptar. Ojo con el argumento con nombre `Nombre: nombre` y con los accesos `p.Nombre`.
4. Al terminar, busca (`Ctrl+F`) si quedó alguna referencia a `Nombre` que NES no detectó.

**Entregable:** el archivo con `NombreComercial` en todos lados y consistente.

## Ejercicio completo: inventario de la farmacia (50 min)

**Archivo:** `Inventario.cs` · **Validación:** `InventarioTests.cs`

La clase `Inventario` ya tiene sus métodos con `throw new NotImplementedException();`. Impleméntalos usando **solo autocompletado**:

| Método | Comportamiento |
|---|---|
| `Agregar(producto)` | Guarda un `ProductoInventario` (`Sku`, `Nombre`, `Stock`, `Precio` y `Caducidad` como `DateOnly`). Si el `Sku` ya existe, lanza `ArgumentException` |
| `Eliminar(sku)` | Elimina el producto. Si no existe, lanza `KeyNotFoundException` |
| `Buscar(texto)` | Devuelve productos cuyo nombre contenga el texto, **sin distinguir mayúsculas** |
| `StockBajo(umbral)` | Devuelve productos con `Stock` menor al umbral |
| `ProximosACaducar(dias, hoy)` | Devuelve los productos que **ya caducaron o caducan en los próximos `dias`**, ordenados del más urgente al menos. `hoy` es opcional (por defecto, la fecha actual) |
| `Reporte()` | Devuelve `ReporteInventario(Productos, Unidades, ValorTotal)` con `ValorTotal = suma(Stock * Precio)` |

### Cómo trabajar

1. Escribe un comentario XML (`///`) en la clase describiendo lo que quieres.
2. Implementa método por método y deja que Copilot proponga.
3. Ejecuta las pruebas con frecuencia:

```bash
dotnet test ejercicios/ej1-autocompletado
```

### Criterios de aceptación

- [ ] Las 8 pruebas de `InventarioTests.cs` pasan.
- [ ] Todos los métodos públicos tienen comentario XML.
- [ ] No usaste el chat.
- [ ] Puedes explicar cada línea del código final.

### Para quien termine antes

Agrega `ActualizarStock(sku, delta)` que impida dejar el stock en negativo, y escribe a mano (con autocompletado) dos pruebas para ella.
