
using Microsoft.EntityFrameworkCore;
using Sabu.DAL;
using Sabu.Entities;
using Sabu.Services.Abstracts;
using Sabu.Services.Implements;

namespace Sabu
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<SabuDbContext>(s => s.UseSqlServer(
                builder.Configuration.GetConnectionString("MSSql")));
            builder.Services.AddScoped<ILanguageService, LanguageService>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
}
