using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL;
using Microsoft.Extensions.Configuration;
using SignalRApi.Model;
using SignalRApi.Hubs;

namespace SignalRApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //PostreSql i ekleme
            builder.Services.AddEntityFrameworkNpgsql().AddDbContext<Context>(opt =>
        opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<VisitorService>();
            builder.Services.AddSignalR();

            builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",   //Server - Client   (Server ýmýz SignalRApi olacak Client imizde SignalRConsume--> bunun                                                                    üzerinden server ý tüketmemize olanak saðlayan metot Cors)
                builder =>
                {
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .SetIsOriginAllowed((host) => true)
                           .AllowCredentials();
                }   //Dýþarýdan herhangi bir kaynaðýn serverýmý yani api projemi tüketmesine olanak saðlayacak olan kýsým
                ));

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

            app.UseRouting();


            app.UseAuthorization();
            app.UseCors("CorsPolicy");
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