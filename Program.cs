using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Arrecadar.Data;
using Refit;
using Arrecadar.Integração.Interfaces;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ArrecadarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ArrecadarContext") ?? throw new InvalidOperationException("Connection string 'ArrecadarContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});


builder.Services.AddRefitClient<IAbacatePayApi>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri("https://api.abacatepay.com"); // ou URL real
        c.DefaultRequestHeaders.Add("Authorization", "abc_dev_fHtxxzkfymzmZnhH6Ef6jTDF");
    });


var app = builder.Build();
app.UseCors("AllowAll");



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
