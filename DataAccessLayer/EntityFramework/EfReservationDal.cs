﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetListReservationByAccepted(int id)
        {
            using(var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Approved" && x.AppUserId == id).ToList();
            }
        }

        public List<Reservation> GetListReservationByOld(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Past" && x.AppUserId == id).ToList();
            }
        }

        public List<Reservation> GetListReservationByWaitApproval(int id)
        {
            using (var context = new Context())        // Context i newledik.
            {

                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Waiting" && x.AppUserId == id).ToList();         //Context içinde yer alan resservation içine inClude(Dahil Et)  
            }
        }

        public List<Reservation> GetAdminListReservationByWaiting()
        {
            using (var context = new Context())        // Context i newledik.
            {

                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Waiting").ToList();         //Context içinde yer alan resservation içine inClude(Dahil Et)  
            }
        }

        public List<Reservation> GetAdminListReservationByAccepted()
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Approved").ToList();
            }
        }

        Context c = new Context();
        public void ChangeToApproveStatus(int id)
        {
            var data = c.Reservations.Find(id);
            data.Status = "Approved";
            c.SaveChanges();
        }

        public void ChangeToOldStatus(int id)
        {
            var data = c.Reservations.Find(id);
            data.Status = "Past";
            c.SaveChanges();
        }

        public List<Reservation> GetAdminListReservationByOld()
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Past").ToList();
            }
        }
    }
}
