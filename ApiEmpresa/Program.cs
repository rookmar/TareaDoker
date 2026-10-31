
using Microsoft.EntityFrameworkCore;
using ApiEmpresa.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string? cadena = builder.Configuration.GetConnectionString("DefaultConnection") ?? "otracadena" ;

builder.Services.AddControllers();
builder.Services.AddDbContext<Conexiones>(opt =>
    //* para Anzure* 
    //opt.UseAzureSql(builder.Configuration.GetConnectionString("ConnectionSQLAnzure") ?? "otracadena"));
    opt.UseMySQL(cadena));
    //esto es para sqlserver
    //opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 
    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();