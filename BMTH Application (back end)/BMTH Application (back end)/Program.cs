using BMTH_Application__back_end_.Middleware;
using BusinessLayer.Interfaces.Store.TShirts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DataLayer.Context;
using DataLayer.Interfaces;
using BusinessLayer.Interfaces.Store.Common;
using BusinessLayer.Interfaces.Store.Orders;
using BusinessLayer.Services.Store.Common;
using BusinessLayer.Services.Store.Orders;
using BusinessLayer.Services.Store.Product;
using DataLayer.Repositories.Store.Orders;
using DataLayer.Repositories.Store.Products;
using BusinessLayer.Domain.User;
using BusinessLayer.Helper.Validator.User;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add Repositories to the container
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
// Add services to the container.
builder.Services.AddScoped<ITShirtService, ProductService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IOrderService, OrderService>();
// Add Validators to the container
builder.Services.AddScoped<IValidator<Register>, RegisterValidator>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Adds Database connection + context
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BMTH_Real")));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BMTH API",
        Version = "v1"
    });

    c.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "To view the JSON info, please fill in the Api key",
        In = ParameterLocation.Header,
        Name = "ApiKey",
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiKey"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configures the ExceptionHandeling
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors("AllowFrontend");

app.UseWhen(
    context => !context.Request.Path.StartsWithSegments("/swagger"),
    branch =>
    {
        branch.UseMiddleware<ApiMiddleWare>();
    });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
