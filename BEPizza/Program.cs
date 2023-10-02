using BEPizza.Models;
using BEPizza.Repositories.Implementations;
using BEPizza.Repositories.Interfaces;
using BEPizza.Services.Implementations;
using BEPizza.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Text;

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
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

//Add JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
        };
    });

builder.Services.AddSwaggerGen(c =>
{
    //c.SwaggerDoc("v1", new OpenApiInfo
    //{
    //    Title = "JWToken_Auth_API",
    //    Version = "v1"
    //});

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {{
            new OpenApiSecurityScheme
            {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
