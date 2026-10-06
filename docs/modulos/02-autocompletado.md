# 2. Autocompletado

**Duración:** 100 min · **Tipo:** teoría breve + 3 ejercicios aislados + ejercicio completo de 50 min

> **Pistas Python y JavaScript**
>
> Los ejemplos de este módulo usan archivos de la pista Python (`src/app.py`, `pytest`). En la pista JavaScript el equivalente es `src/app.js` con Jest y en la pista C# `src/Farmacia.Api/*.cs` con xUnit: consulta las [equivalencias](../pistas.md#equivalencias-de-archivos).

Todos los archivos están en `ejercicios/ej1-autocompletado/`. Enunciados en el [Ejercicio 1](../ejercicios/ej1-autocompletado.md).

## 2.1 Sugerencias inline (ghost text)

Mientras escribes, Copilot muestra texto gris con lo que cree que sigue.

| Acción | Atajo |
|---|---|
| Aceptar | `Tab` |
| Descartar | `Esc` |
| Siguiente / anterior alternativa | `Alt+]` / `Alt+[` |
| Aceptar solo una palabra | `Ctrl+→` |
| Ver varias alternativas | `Ctrl+Enter` |

**Qué influye en la calidad:** nombres claros, firmas con tipos, archivos abiertos relacionados y código cercano.

**Ejercicio aislado A (10 min):** `tramo_a_ghost_text.py` (JS: `tramoA_ghostText.js`; C#: `TramoA_GhostText.cs`).

## 2.2 Desarrollo guiado por comentarios

Escribes **qué** quieres en un comentario y Copilot propone el **cómo**.

Patrón útil:

1. Comentario preciso (entrada, salida, casos especiales).
2. Firma de la función.
3. Revisar, ajustar el **comentario** si la sugerencia no es la deseada.

> **Consejo**
>
> Si Copilot falla, mejora el comentario antes de editar el código a mano. Así aprendes a comunicar la intención.

**Ejercicio aislado B (10 min):** `tramo_b_comentarios.py` (JS: `tramoB_comentarios.js`; C#: `TramoB_Comentarios.cs`).

## 2.3 Next Edit Suggestions (NES)

NES predice **el siguiente cambio que harás**, incluso en otra línea del archivo. Es ideal para refactors en cascada: renombrar un campo, cambiar la firma de una función y propagar el cambio.

- Actívalo con `github.copilot.nextEditSuggestions.enabled`.
- Se acepta con `Tab`; una flecha en el margen indica que hay una edición sugerida más abajo.
- **Revisa cada edición**: NES propone, no garantiza que sea correcta.

**Ejercicio aislado C (10 min):** `tramo_c_nes.py` (JS: `tramoC_nes.js`; C#: `TramoC_Nes.cs`).

## 2.4 Ejercicio completo (50 min)

Construcción de `inventario.py` (Python), `inventario.js` (JavaScript) o `Inventario.cs` (C#) usando **solo autocompletado**. Validación con `pytest`, `jest` o `dotnet test`. Ver [Ejercicio 1](../ejercicios/ej1-autocompletado.md).

## Puntos clave

1. El ghost text es tan bueno como el contexto que le das.
2. Un comentario claro vale más que cinco correcciones.
3. NES ahorra tiempo en refactors, pero exige revisión.
