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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Tadd(Comment t)
        {
            _commentDal.Insert(t);
        }

        public void Tdelete(Comment t)
        {
            _commentDal.Delete(t);
        }

        public Comment TgetById(int id)
        {
           return _commentDal.GetById(id);
        }

        public List<Comment> TGetList()
        {
           return _commentDal.GetList();
        }

        public List<Comment> TGetListCommentWithDestination()
        {
            return _commentDal.GetListCommentWithDestination();
        }

        public List<Comment> TGetListtByIf(int id) //Destination id)
        {
            return _commentDal.GetListByIf(x => x.DestinationId == id);

        }

        public void Tupdate(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
