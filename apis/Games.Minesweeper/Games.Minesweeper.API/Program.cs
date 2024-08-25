using Games.Minesweeper.Domain.Configuration;
using Games.Minesweeper.Domain.Interfaces;
using Games.Minesweeper.Infrastructure;
using System.Reflection;
using Games.Minesweeper.Infrastructure.Profiles;
using Games.Minesweeper.API.Profiles;
using Games.Minesweeper.Domain.Handlers;
using FluentValidation;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;

namespace Games.Minesweeper.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddScoped<IGameRepository, GameRepository>();
        builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
        builder.Services.AddSingleton<IDatabaseConnectionFactory, DatabaseConnectionFactory>();
        builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(Program)),
          Assembly.GetAssembly(typeof(MinesweeperProfile)),
          Assembly.GetAssembly(typeof(ResponseProfiles)));
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetGameHandler).Assembly));
        builder.Services.AddValidatorsFromAssemblyContaining<Program>();
        builder.Services.AddFluentValidationRulesToSwagger();

        var app = builder.Build();

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
