using BMTH_Application__back_end_.Middleware;
using BusinessLayer.Interfaces.Store.TShirts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using BusinessLayer.Services.Store.TShirts;
using BusinessLayer.Interfaces.Store.Common;
using BusinessLayer.Services.Store.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITShirtRepository, TShirtRepository>();
builder.Services.AddScoped<ITShirtService, TShirtService>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Adds Database connection + context
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BMTH_Test")));

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

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
    try
    {
        Console.WriteLine("Testing database connection...");
        db.Database.OpenConnection();
        Console.WriteLine("Database connection succeeded!");
        db.Database.CloseConnection();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Database connection failed!");
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine(ex.ToString());
        Console.WriteLine("------------------------------------------------------");
    }
}


app.Run();
