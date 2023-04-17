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

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
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
            throw new NotImplementedException();
        }

        public Reservation TgetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> TGetList()
        {
            throw new NotImplementedException();
        }

        public void Tupdate(Reservation t)
        {
            throw new NotImplementedException();
        }
    }
}
