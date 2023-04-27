using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAccountDal : GenericUnitofWorkRepository<Account>, IAccountDal
    {
        public EfAccountDal(Context context) : base(context)
        {
            // GenericUnitofWorkRepository da tanımlamış olduğüumuz constructor yappıyı buranın içine enjekte ettik.
        }
    }
}
