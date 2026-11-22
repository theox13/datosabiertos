# AGENTS.md — DatosAbiertos.eu

> Contexto para una nueva ventana de trabajo. No hace falta releer la investigación completa: está resumida en `C:\Users\iniak\Documents\Proyectos\OpenData`.

## Qué es

Portal de datos públicos de España. Primer módulo: **farmacias de guardia**. Web responsive + API. Activo a largo plazo, bajo coste, 5-6 h/semana.

## Documentación (leer en este orden)

1. `C:\Users\iniak\Documents\Proyectos\OpenData\DECISIONES.md` — fuente de verdad.
2. `...\PLAN.md` — semanas y entregables.
3. `...\ARQUITECTURA.md` — modelo, API, SEO/GEO, despliegue.
4. `...\FUENTES.md` — datasets y licencias.
5. `...\LEGAL.md` — licencias, privacidad, TDM.

## Estado actual

- **Semana 1 completada:** solución `DatosAbiertos.slnx`, `DatosAbiertos.Core`, `DatosAbiertos.Web`, `DatosAbiertos.Tests`, esquema PostgreSQL, Docker Compose, CI y `/health`.
- **Siguiente:** semana 2 — ETL de Navarra + página `/fuentes`.
- **Repo local:** `C:\PROYECTOS\datosabiertos`; remoto `https://github.com/theox13/datosabiertos` (`origin`), rama `main`.
- **Base de datos:** PostgreSQL 19 local en `localhost:5432`, base `datosabiertos`, usuario `datosabiertos`; cadena en **user-secrets** (no se commitea). Migración `InitialCreate` aplicada.
- **Docker:** no instalado en A8_MAX; `docker compose` preparado para despliegue.

## Stack

- .NET 10 LTS (`net10.0`), ASP.NET Core Razor Pages + Minimal API.
- PostgreSQL 17+, EF Core 10 + Npgsql.
- Hangfire o `BackgroundService` para jobs (aún no instalado).
- Leaflet + OpenStreetMap (aún no instalado).
- xUnit, WebApplicationFactory, Testcontainers (Testcontainers aún no instalado).
- GA4 con Consent Mode v2 (aún no instalado).

## Estructura

```
DatosAbiertos.slnx
src/
  DatosAbiertos.Core/
    Entities/            # Fuente, Provincia, Municipio, Farmacia, Guardia, RawPayload, IngestRun
    Data/
      DatosAbiertosDbContext.cs
      Configurations/    # mapeo EF Core
      Migrations/        # migración InitialCreate
  DatosAbiertos.Web/
    Program.cs           # Razor Pages + /health + DbContext
    Pages/
    appsettings.json     # cadena de conexión de desarrollo
tests/
  DatosAbiertos.Tests/
    Domain/GuardiaTests.cs
    Web/HealthEndpointTests.cs
```

## Comandos

```powershell
dotnet restore
dotnet build
dotnet test

dotnet tool restore
dotnet user-secrets set "ConnectionStrings:Default" "Host=localhost;Port=5432;Database=datosabiertos;Username=datosabiertos;Password=<tu-password>" --project src/DatosAbiertos.Web
dotnet tool run dotnet-ef migrations add <Nombre> --project src/DatosAbiertos.Core --startup-project src/DatosAbiertos.Web --output-dir Data/Migrations
dotnet tool run dotnet-ef database update --project src/DatosAbiertos.Core --startup-project src/DatosAbiertos.Web

dotnet run --project src/DatosAbiertos.Web
docker compose up -d
```

## Convenciones

- C# con `nullable` activado, `async`/`await` y `CancellationToken` en IO.
- Identificadores en inglés; UI, textos y comentarios en español.
- Fechas UTC en base de datos; `Europe/Madrid` solo en presentación.
- Coordenadas WGS84; teléfonos E.164; ids UUIDv7.
- EF Core con migraciones; nada de SQL ad hoc en producción.
- Logs estructurados (Serilog) cuando se añada.
- Tests de parser con fixtures reales; integración con PostgreSQL cuando haga falta.
- Secretos en variables de entorno o user-secrets; nunca en el repo.
- Frontend: HTML server-rendered y Bootstrap 5. **Sin jQuery.** HTMX/Alpine solo cuando una feature lo justifique; Leaflet es vanilla JS.

## Límites (no hacer sin pedirlo)

- No scraping en el MVP; fase 2 con revisión de condiciones de uso.
- No AdSense, cuentas, favoritos, notificaciones ni app nativa en el MVP.
- No mostrar datos que no cubran el día de hoy: 503 y fuera del sitemap.
- No publicar el dataset CC BY antes de 3 meses.
- No cobrar a crawlers ni añadir pay-per-crawl.
- No refactorizar fuera del alcance de la tarea.
- No cambiar el esquema sin migración y tests.
- No commitear `bin/`, `obj/`, `.vs/`, secretos ni cadenas de producción.

## GitHub

- A8_MAX **no autentica** contra GitHub (Git Credential Manager neutralizado). No intentes `git push` desde aquí.
- El repo local está inicializado; el usuario creará el remoto y hará push desde POT188 o con credenciales.
- Primer commit sugerido: `chore: esqueleto semana 1`.

## Definición de hecho

1. `dotnet build` y `dotnet test` en verde.
2. Migración aplicada y reversible.
3. Tests del parser/endpoint afectado.
4. Documentación actualizada si cambia una decisión.
5. Sin warnings nuevos relevantes.
