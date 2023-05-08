
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DataTrabsferObjects.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using MDS_Tour.CQRS.Handlers.DestinationHandlers;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace MDS_Tour
{
    public class Program
    {
        

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<GetAllDestinationQueryHandler>();
            builder.Services.AddScoped<GetDestinationByIdQueryHandler>();
            builder.Services.AddScoped<CreateDestinationCommandHandler>();
            builder.Services.AddScoped<RemoveDestinationCommandHandler>();
            builder.Services.AddScoped<UpdateDestinationCommandHandler>();
            //Sadece CQRS kullan�rken her bir Handle i�in ayr� ayr� scoped tan�ml�yorduk art�k MediatR ile art�k buna gerek kalmayacak.
            builder.Services.AddMediatR(typeof(Program));


            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddDbContext<Context>();
            builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

            // Api taraf�ndan gelen istekleri kar��layaca��z.
            builder.Services.AddHttpClient();

            // container Dependency injection uygulad�k ve ekstra new lemeden �a��rd�k methodu
           builder.Services.ContainerDependicies();
            // Auto Mapper �n eklenmesi
            builder.Services.AddAutoMapper(typeof(Program));


            //Announcement Add Validasyon i�in 
            builder.Services.CustomValidator();

            //builder.Services.AddControllersWithViews().AddFluentValidation();


            // Proje seviyesinde authorizationu kullanmak.
            builder.Services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            builder.Services.AddMvc();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=SignIn}/{id?}");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });


            app.Run();
        }
    }
}