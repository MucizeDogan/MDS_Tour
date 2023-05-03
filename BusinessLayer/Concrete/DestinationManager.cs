using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DestinationManager : IDestinationService
    {
        IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public void Tadd(Destination t)
        {
             _destinationDal.Insert(t);
        }

        public void Tdelete(Destination t)
        {
            _destinationDal.Delete(t);
        }

        public Destination TgetById(int id)
        {
           
            return _destinationDal.GetById(id);
        }

        public Destination TGetDestinationWithGuideList(int id)
        {
            return _destinationDal.GetDestinationWithGuideList(id);
        }

        public List<Destination> TGetList()
        {
           return _destinationDal.GetList();
        }

        public void Tupdate(Destination t)
        {
            _destinationDal.Update(t);
        }
    }
   
}
