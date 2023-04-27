using BusinessLayer.Abstract;
using BusinessLayer.Abstract.AbstractUoW;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.ConcreteUnitofWork;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitofWork;
using DTOLayer.DataTrabsferObjects.AnnouncementDTOs;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class Dependencies
    {
        public static void ContainerDependicies(this IServiceCollection Services)
        {
            //Comment
            Services.AddScoped<ICommentService, CommentManager>();
            Services.AddScoped<ICommentDal, EfCommentDal>();
            
            //Destination
            Services.AddScoped<IDestinationService, DestinationManager>();
            Services.AddScoped<IDestinationDal, EfDestinationDal>();

            //AppUser
            Services.AddScoped<IAppUserService, AppUserManager>();
            Services.AddScoped<IAppUserDal, EfAppUserDal>();

            //Reservation
            Services.AddScoped<IReservationService, ReservationManager>();
            Services.AddScoped<IReservationDal, EfReservationDal>();

            //Guide
            Services.AddScoped<IGuidesService, GuideManager>();
            Services.AddScoped<IGuidesDal, EfGuidesDal>();

            //Excel
            Services.AddScoped<IExcelService, ExcelManager>();

            //ContactUs
            Services.AddScoped<IContactUsService, ContactUsManager>();
            Services.AddScoped<IContactUsDal, EfContactUsDal>();

            //Announcement
            Services.AddScoped<IAnnouncementService,AnnouncementManager>();
            Services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();

            //Account
            Services.AddScoped<IAccountService, AccountManager>();
            Services.AddScoped<IAccountDal, EfAccountDal>();

            // UNIT OF WORK
            Services.AddScoped<IUnitofWorkDal, UnitofWorkDal>();
       
        }
        public static void CustomValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AnnouncementAddDto>, AnnouncementValidator>(); 
        }
    }
}
