using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
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
        IDataResult<QuestionDetailDto> GetQuestionDetails(int questionId);
        public IDataResult<Question> GetByQuestionId(int id);
        public IDataResult<List<Question>> GetByCategoryId(int id);
        public IDataResult<List<Question>> GetAll();
        public IDataResult<int> CountNumberOfQuestionInCategory(int categoryId);
    }
}
