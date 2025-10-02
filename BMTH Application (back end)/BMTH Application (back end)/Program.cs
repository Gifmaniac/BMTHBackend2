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

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5174/")
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
