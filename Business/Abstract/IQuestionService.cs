using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IQuestionService
    {
        public IResult Add(Question question);
        public IResult Delete(Question question);
        public IResult Update(Question question);
        public IDataResult<Question> GetByQuestionId(int id);
        public IDataResult<List<Question>> GetAll();
    }
}
