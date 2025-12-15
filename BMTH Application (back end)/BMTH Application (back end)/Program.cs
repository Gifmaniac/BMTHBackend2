using System.Text;
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
using BusinessLayer.Interfaces.User;
using BusinessLayer.Services.User;
using DataLayer.Interfaces.User;
using DataLayer.Repositories.User;
using FluentValidation;
using BusinessLayer.Interfaces.Helper;
using Contracts.DTOs.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using BMTH_Application_back_end_.Middleware;
using BusinessLayer.Domain.Store.Products;
using BusinessLayer.Helper.Validator.Store;
using BusinessLayer.Interfaces.Store;



var builder = WebApplication.CreateBuilder(args);

// Add Repositories to the container
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IUserRegisterRepository, UserRegisterRepository>();
builder.Services.AddScoped<IUserLoginRepository, UserLoginRepository>();
// Add services to the container.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<ILoginService, LoginService>();
// Add Validators to the container
builder.Services.AddScoped<IValidator<Register>, RegisterValidator>();
builder.Services.AddScoped<IValidator<LoginUserDto>, LoginValidator>();
builder.Services.AddScoped<IValidator<Products>, ProductsValidator>();
builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Adds Database connection + context
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BMTH_Real")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BMTH API",
        Version = "v1"
    });
});

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]
                    ?? throw new InvalidOperationException("Jwt:Key missing"))
            )
        };

        // Allow JWT from cookie
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                if (context.Request.Cookies.TryGetValue("jwt", out var token))
                    context.Token = token;

                return Task.CompletedTask;
            }
        };
    });

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();


// Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.DocumentTitle = "BMTH API Docs";
    c.InjectJavascript("/swagger-auth.js");
});


// Middleware
app.UseStaticFiles();
app.UseCors("AllowFrontend");
app.UseMiddleware<ExceptionMiddleware>();

// Block everything except login & swagger until logged in
app.Use(async (context, next) =>
{
    var path = context.Request.Path;

    if (path.StartsWithSegments("/swagger"))
    {
        await next();
        return;
    }

    if (path == "/swagger-auth.js")
    {
        await next();
        return;
    }

    if (path.StartsWithSegments("/api/auth"))
    {
        await next();
        return;
    }

    // Everything else requires authentication
    if (!context.User.Identity!.IsAuthenticated)
    {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Unauthorized");
        return;
    }

    await next();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();