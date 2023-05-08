using Microsoft.EntityFrameworkCore;
using SignalRApiForSql.DAL;
using SignalRApiForSql.Hubs;
using SignalRApiForSql.Models;

namespace SignalRApiForSql
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<VisitorService>();
            builder.Services.AddSignalR();

            builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",   //Server - Client   (Server �m�z SignalRApi olacak Client imizde SignalRConsume--> bunun                                                                    �zerinden server � t�ketmemize olanak sa�layan metot Cors)
                builder =>
                {
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .SetIsOriginAllowed((host) => true)
                           .AllowCredentials();
                }   //D��ar�dan herhangi bir kayna��n server�m� yani api projemi t�ketmesine olanak sa�layacak olan k�s�m
                ));
            builder.Services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(builder.Configuration["DefaultConnection"]);
            });

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
            }

            app.UseRouting(); // EndpointRoutingMiddleware'yi ekleyin.
            app.UseCors("CorsPolicy");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // endpoints.MapControllers();
                endpoints.MapHub<VisitorHub>("/VisitorHub");
            });

            app.MapControllers();

            app.Run();
        }
    }
}