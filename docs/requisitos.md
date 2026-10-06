# Requisitos previos

Completa esta lista **antes del curso**. Si tienes problemas, avisa al instructor con anticipación. Revisa la pestaña de tu pista (Python, JavaScript o C#); ver [Pistas](pistas.md).

## Cuentas

- [ ] Cuenta de GitHub.
- [ ] Licencia activa de GitHub Copilot (individual u otorgada por tu organización). Verifica en [github.com/settings/copilot](https://github.com/settings/copilot).

## Software (si no usarás Codespaces)

- [ ] [Visual Studio Code](https://code.visualstudio.com/) en su versión estable más reciente.
- [ ] Extensiones **GitHub Copilot** y **GitHub Copilot Chat** (y **GitHub Pull Requests** para la demo final).
- [ ] Git.

- [ ] [.NET SDK](https://dotnet.microsoft.com/download) 10 (comprueba con `dotnet --version`).
- [ ] Extensión **C# Dev Kit** de VS Code (o Visual Studio 2022 o superior, o JetBrains Rider).

## Verificación (5 minutos)

```bash
git clone <url-del-repositorio>
cd <carpeta-del-repositorio>
dotnet test tests/Farmacia.Api.Tests
```

Debes ver `Superado: 2` (la primera vez descarga los paquetes NuGet).

Después, en VS Code:

- [ ] Escribe un comentario en un archivo de código y comprueba que aparece texto gris de sugerencia.
- [ ] Abre el chat de Copilot (`Ctrl+Alt+I`) y escribe un mensaje.

> **Alternativa recomendada**
>
> Usa **GitHub Codespaces** (*Code → Codespaces → Create codespace on main*). El entorno queda configurado automáticamente por `.devcontainer/`.

## Política de uso

Trabajaremos con código y datos de ejemplo (una farmacia ficticia). **No pegues código, datos ni credenciales de clientes** en el chat durante el curso, y **nunca datos de pacientes, recetas ni folios reales**.
