﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>   // daha öncesinde : DbContext idi
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-RHMNBG1\\SQLEXPRESS;database=MDS_TourDb;integrated security=true;") ;

        }

        public DbSet<About> Abouts { get; set; } //Buraya tanımladığımız property ismi tablo ismimiz olacak , -s takısı almış hali tablo ismi
        public DbSet<About2> About2s { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Destination>Destinations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Feature2> Feature2s { get; set; }
        public DbSet<Guides> Guidess { get; set; }
        public DbSet<NewsLetter> NewsLetterss { get; set; }

        public DbSet<SubAbout> SubAboutss { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

    }
}
