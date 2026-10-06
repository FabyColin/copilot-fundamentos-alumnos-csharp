# Pistas: Python, JavaScript o C#

El curso tiene tres pistas con los mismos objetivos, tiempos y estructura. Elige la que prefiera tu grupo; los módulos de teoría son iguales para todas.

| | Pista Python | Pista JavaScript | Pista C# |
|---|---|---|---|
| **Backend** | Flask | Express | ASP.NET Core (minimal APIs) |
| **Interfaz (ejercicio 5)** | Plantilla Jinja con HTML, CSS y JS | Componente React (Vite) | Página Razor (Razor Pages) |
| **Pruebas** | pytest, pytest-cov | Jest, supertest, React Testing Library | xUnit, WebApplicationFactory, coverlet |
| **Entorno** | Python 3.12 | Node.js 20 o superior | .NET SDK 10 |
| **Instalación** | `pip install -r src/requirements.txt` | `npm install` | `dotnet restore` |
| **Correr la API** | `python src/app.py` (puerto 5000) | `npm start` (puerto 5000) | `dotnet run --project src/Farmacia.Api --urls http://localhost:5000` |
| **Correr las pruebas** | `pytest src` | `npm test` | `dotnet test tests/Farmacia.Api.Tests` |

## Equivalencias de archivos

Los módulos de teoría usan ejemplos de la pista Python. En las otras pistas, el equivalente es:

| Python | JavaScript | C# |
|---|---|---|
| `src/app.py` | `src/app.js` | `src/Farmacia.Api/Program.cs` y `*Endpoints.cs` |
| `src/descuentos.py` | `src/descuentos.js` | `src/Farmacia.Api/Descuentos.cs` |
| `src/tests/test_app.py` | `src/tests/app.test.js` | `tests/Farmacia.Api.Tests/ApiTests.cs` |
| `src/templates/catalogo.html` | `web/Catalogo.jsx` | `src/Farmacia.Api/Pages/Catalogo.cshtml` |
| `ejercicios/ej1-autocompletado/inventario.py` | `ejercicios/ej1-autocompletado/inventario.js` | `ejercicios/ej1-autocompletado/Inventario.cs` |
| `pytest`, `/tests` con pytest | `jest`, `/tests` con Jest | `dotnet test`, `/tests` con xUnit |
| `requirements.txt` | `package.json` | `Farmacia.Api.csproj` |

## Rutas de los enunciados

Las rutas de los enunciados (`src/`, `tests/`, `ejercicios/`, `web/`) son **relativas a la carpeta de la pista** (`pistas/python/`, `pistas/javascript/` o `pistas/csharp/` en el repositorio del instructor; la raíz del repositorio de alumnos).

## Qué es distinto en el Ejercicio 3

El tercer bug es una división entre cero. En Python y en C# (con `decimal`) detiene el programa con un error. En JavaScript, `0 / 0` da `NaN` y el programa sigue: allí los **tres** bugs son silenciosos. Es una diferencia real del lenguaje y hace el ejercicio más exigente para quien lo verifica.

## Qué es distinto en el ejercicio opcional

En C# el propio tipo de la petición descarta valores como `"abc"` o `1.5`, así que el defecto de validación se reduce a lo que el tipo no cubre: un `delta` en cero, ausente o que deja el stock en negativo.
