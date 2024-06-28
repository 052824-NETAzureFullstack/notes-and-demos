using Microsoft.EntityFrameworkCore;
using MusicAPI.Data;
using System.Text.Json.Serialization;

namespace MusicAPI.App;

public class Program
{
    public static void Main(string[] args)
    {
        var  CORSPolicy = "CORSPolicy";

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddCors( options =>
        {
            options.AddPolicy( name: CORSPolicy,
                                policy => 
                                {
                                    policy.AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                                });
        });

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Add Database Context for EF Core
        builder.Services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("Cloud"));
        });

        var app = builder.Build();

        app.UseCors(CORSPolicy);
        
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
    }
}
