using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Arrecadar.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ArrecadarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ArrecadarContext") ?? throw new InvalidOperationException("Connection string 'ArrecadarContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsRestrito", policy =>
    {
        policy
            .WithOrigins( "http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

app.UseCors("CorsRestrito");

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
