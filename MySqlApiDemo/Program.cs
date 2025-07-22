using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using MySqlApiDemo.Data;
using MySqlApiDemo.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql("Server=localhost;Database=mysqldb;User=root;Password=Sattu@321",
        new MySqlServerVersion(new Version(8, 0, 32))));

builder.Services.AddControllers();
builder.Services.AddScoped<IVehicleService, VehicleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.UseHttpsRedirection();



app.Run();


