using BEPizza.Models;
using BEPizza.Repositories.Implementations;
using BEPizza.Repositories.Interfaces;
using BEPizza.Services.Implementations;
using BEPizza.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PizzaContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("BEPizzaContext")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITypeUserService, TypeUserService>();
builder.Services.AddScoped<ITypeUserRepository, TypeUserRepository>();
builder.Services.AddScoped<ISizePizzaService, SizePizzaService>();
builder.Services.AddScoped<ISizePizzaRepository, SizePizzaRepository>();
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();
builder.Services.AddScoped<IPizzaService, PizzaService>();

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
