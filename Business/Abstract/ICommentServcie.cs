using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentServcie
    {
        public IResult Add(Comment comment);
        public IResult Delete(Comment comment);
        public IResult Update(Comment comment);
        public IDataResult<Comment> GetByCommentId(int id);
        public IDataResult<List<Comment>> GetAll();
    }
}
