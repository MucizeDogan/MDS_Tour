using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;

        public List<Reservation> TGetAdminListReservationByOld()
        {
            return _reservationDal.GetAdminListReservationByOld();  
        }

        public void TChangeToOldStatus(int id)
        {
            _reservationDal.ChangeToOldStatus(id);
        }

        public void TChangeToApproveStatus(int id)
        {
            _reservationDal.ChangeToApproveStatus(id);
        }

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }
        public List<Reservation> TGetAdminListReservationByWaiting()
        {
            return _reservationDal.GetAdminListReservationByWaiting();
        }

        public List<Reservation> TGetAdminListReservationByAccepted()
        {
            return _reservationDal.GetAdminListReservationByAccepted();
        }

       
        public List<Reservation> GetListReservationByAccepted(int id)
        {
            return _reservationDal.GetListReservationByAccepted(id);
        }

        public List<Reservation> GetListReservationByOld(int id)
        {
            return _reservationDal.GetListReservationByOld(id);
        }

        public List<Reservation> GetListReservationByWaitApproval(int id)
        {
          return  _reservationDal.GetListReservationByWaitApproval(id);
        }

        public void Tadd(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void Tdelete(Reservation t)
        {
            _reservationDal.Delete(t);
        }

        public Reservation TgetById(int id)
        {
            return _reservationDal.GetById(id);
        }

        public List<Reservation> TGetList()
        {
          return  _reservationDal.GetList();
        }

        public void Tupdate(Reservation t)
        {
            throw new NotImplementedException();
        }
    }
}
