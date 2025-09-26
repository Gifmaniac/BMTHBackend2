using BMTH_Application__back_end_.Middleware;
using BusinessLayer.Services;
using DataLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<TShirtRepository>();
builder.Services.AddScoped<TShirtService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMiddleware<ApiMiddleWare>();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
