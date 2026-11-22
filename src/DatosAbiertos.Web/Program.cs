using DatosAbiertos.Core.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new InvalidOperationException("Falta la cadena de conexión 'Default'.");

builder.Services.AddDbContext<DatosAbiertosDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.MapGet("/health", () => Results.Ok(new
{
    status = "ok",
    service = "datosabiertos",
    timestamp = DateTimeOffset.UtcNow
}));

app.MapRazorPages()
   .WithStaticAssets();

app.Run();

public partial class Program { }
