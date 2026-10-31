using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using AppEmpresa.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// 👇 AGREGA ESTA LÍNEA: Esto registra el IHttpClientFactory que tu página está pidiendo
builder.Services.AddHttpClient();

// 👇 (Opcional pero recomendado) Configura la URL base de tu API aquí
var apiUrl = builder.Configuration["ApiSettings:BaseUrl"]
    ?? "http://localhost:5212/api/clientes";

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(apiUrl)
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();