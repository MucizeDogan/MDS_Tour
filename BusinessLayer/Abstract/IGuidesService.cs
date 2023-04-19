using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGuidesService : IGenericService<Guides>
    {
        void TChangeToTrueStatus(int id);

        void TChangeToFalseStatus(int id);
    }
}
