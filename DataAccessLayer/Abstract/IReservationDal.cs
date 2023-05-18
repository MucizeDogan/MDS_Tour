using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        //Parametreye göre (dışarıdan id) listeleme işlemi yapılacak.  
        List<Reservation> GetListReservationByWaitApproval(int id);
        List<Reservation> GetListReservationByAccepted(int id);
        List<Reservation> GetListReservationByOld(int id);
        List<Reservation> GetAdminListReservationByWaiting();
        List<Reservation> GetAdminListReservationByAccepted();
        List<Reservation> GetAdminListReservationByOld();
        void ChangeToApproveStatus(int id);
        void ChangeToOldStatus(int id);

    }
}
