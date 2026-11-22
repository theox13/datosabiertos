# DatosAbiertos.eu

Portal de datos públicos de España. Primer módulo: **farmacias de guardia**.

- Web responsive + API.
- ASP.NET Core (.NET 10 LTS), PostgreSQL, Razor Pages + Minimal API.
- Documentación y decisiones: `C:\Users\iniak\Documents\Proyectos\OpenData`.

## Estado

**Semana 1 completada:** solución, esquema inicial, Docker Compose, CI y endpoint `/health`.
Siguiente: semana 2, ETL de Navarra + página `/fuentes`.

## Requisitos

- .NET SDK 10 o superior (probado con SDK 11.0.100 compilando `net10.0`).
- PostgreSQL 17+ o Docker con Compose.
  - En esta máquina (A8_MAX) Docker **no está instalado**; el `docker compose` queda preparado para cuando se instale.

## Arranque rápido

```powershell
dotnet restore
dotnet build
dotnet test

# Base de datos (si hay Docker)
docker compose up -d

# Migraciones
dotnet tool restore
dotnet tool run dotnet-ef database update --project src/DatosAbiertos.Core --startup-project src/DatosAbiertos.Web

# Web
dotnet run --project src/DatosAbiertos.Web
```

- Web: `http://localhost:5002`
- Salud: `http://localhost:5002/health`

La cadena de conexión de desarrollo está en `src/DatosAbiertos.Web/appsettings.json` y es solo para local.

## Estructura

```
src/
  DatosAbiertos.Core/   # entidades, EF Core, migraciones
  DatosAbiertos.Web/    # Razor Pages + Minimal API
tests/
  DatosAbiertos.Tests/  # dominio y endpoints
```

## Base de datos

- PostgreSQL 17+.
- Esquema inicial: `fuentes`, `provincias`, `municipios`, `farmacias`, `guardias`, `raw_payloads`, `ingest_runs`.
- Migración: `InitialCreate` en `src/DatosAbiertos.Core/Data/Migrations`.

## CI

GitHub Actions en `.github/workflows/ci.yml`: restore, build y test en cada push/PR a `main`.

## Licencia

MIT. Ver [LICENSE](LICENSE).
