using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Employee.Data;
using Employee.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql("Server=localhost;Database=register_employee;User=root;Password=Sattu@321",
        new MySqlServerVersion(new Version(8, 0, 32))));

builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.MapControllers();
app.UseHttpsRedirection();


app.Run();

