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
    public class GuideManager : IGuidesService
    {
        IGuidesDal _guidesDal;

        public GuideManager(IGuidesDal guidesDal)
        {
            _guidesDal = guidesDal;
        }

        public void Tadd(Guides t)
        {
            _guidesDal.Insert(t);
        }

        public void TChangeToFalseStatus(int id)
        {
            _guidesDal.ChangeToFalseStatus(id);
        }

        public void TChangeToTrueStatus(int id)
        {
            _guidesDal.ChangeToTrueStatus(id);
        }

        public void Tdelete(Guides t)
        {
            throw new NotImplementedException();
        }

        public Guides TgetById(int id)
        {
           return _guidesDal.GetById(id);
        }

        public List<Guides> TGetList()
        {
           return _guidesDal.GetList();
        }

        public void Tupdate(Guides t)
        {
            _guidesDal.Update(t);
        }
    }
}
