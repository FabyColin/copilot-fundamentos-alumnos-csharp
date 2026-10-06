# GitHub Copilot: Fundamentos (pista C#)

Material para alumnos del curso de 1 día. Trabajarás con **C# y ASP.NET Core** (minimal APIs y Razor Pages), y probarás con **xUnit**.

## Caso de práctica

Los ejercicios usan **Farmacia Demo**, un caso ficticio con medicamentos, existencias, caducidades, recetas y descuentos. Los datos y reglas son didácticos; no representan precios ni requisitos regulatorios reales. No pegues en el chat datos de pacientes, recetas ni folios reales.

## Qué aprenderás

- Usar sugerencias inline, Next Edit Suggestions y desarrollo guiado por comentarios.
- Trabajar con el chat (Ask, Plan, Agent), slash commands y selección de modelo.
- Dar contexto y reglas a Copilot con variables, custom instructions y prompt files.
- Escribir prompts efectivos e iterar sobre las respuestas.
- Entender y corregir código legacy.
- Delegar cambios multi-archivo al agente con control y revisión humana.
- Generar pruebas con xUnit y llevarlas a verde.
- Pasar de un mockup a una página Razor.

## Estructura

| Carpeta | Contenido |
|---|---|
| `docs/` | Módulos del curso, enunciados de los ejercicios, agenda y recursos |
| `ejercicios/` | Proyectos de arranque de los 5 ejercicios (`Ejercicios.sln`) |
| `src/Farmacia.Api/` | API de la farmacia en ASP.NET Core (datos ficticios) |
| `tests/Farmacia.Api.Tests/` | Pruebas de la API (`Farmacia.sln`) |
| `.devcontainer/` | Entorno listo para Codespaces o Dev Containers |

## Los 5 ejercicios

| # | Ejercicio | Tiempo |
|---|---|---|
| 1 | [Autocompletado](docs/ejercicios/ej1-autocompletado.md): 3 tramos aislados y módulo de inventario | 30 + 50 min |
| 2 | [Chat, contexto y prompting](docs/ejercicios/ej2-chat-contexto-prompting.md) | 30 min |
| 3 | [Rescata el script legacy](docs/ejercicios/ej3-codigo-legacy.md) | 30 min |
| 4 | [Agent mode: descuentos y pruebas en verde](docs/ejercicios/ej4-agent-descuentos.md) | 55 min |
| 5 | [Del mockup a una página Razor](docs/ejercicios/ej5-imagen-a-codigo.md) | 30 min |

**Opcional:** [Revisa el Pull Request](docs/ejercicios/ej-opcional-revision-pr.md) (20 min). No está en la agenda; es para quien termine antes o quiera practicar después.

Empieza por los [requisitos previos](docs/requisitos.md) y la [agenda](docs/agenda.md).

## Inicio rápido

La opción recomendada es **GitHub Codespaces** (*Code → Codespaces → Create*), que instala todo automáticamente.

En local (.NET SDK 10):

```bash
git clone <url-de-este-repositorio>
cd <carpeta-del-repositorio>
dotnet test tests/Farmacia.Api.Tests      # pruebas de la API
dotnet run --project src/Farmacia.Api --urls http://localhost:5000
```

Los ejercicios 1, 2, 3 y opcional se validan con `dotnet test ejercicios/<carpeta>`; las instrucciones están en cada enunciado.

## Licencia

MIT. Consulta [LICENSE](LICENSE).
