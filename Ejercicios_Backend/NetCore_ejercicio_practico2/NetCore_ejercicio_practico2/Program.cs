using NetCore_ejercicio_practico2.Data;
using NetCore_ejercicio_practico2.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var sqlConfiguracion = new sqlConfiguracion(builder.Configuration.GetConnectionString("sqlConexion"));

builder.Services.AddSingleton(sqlConfiguracion);
builder.Services.AddScoped<Iclientes, clientes>();
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
