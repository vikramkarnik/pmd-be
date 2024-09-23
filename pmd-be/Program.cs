using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pmd_be.Extensions;
using pmd_be.Models;
using pmd_be.Services;

namespace pmd_be;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();
        builder.Logging.AddDebug();
        // Add services to the container.
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
        });
        builder.Services.AddControllers();
        builder.Services.AddDbContext<PmdDbContext>(opt => opt.UseInMemoryDatabase("ProductsDb"));
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IProductService, ProductService>();

        var app = builder.Build();

        app.UseCors("AllowAll");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseSeedData(app.Services.GetRequiredService<ILogger<Program>>());
        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}