using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;
        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
    }
        public IResult Add(Question question)
        {
            _questionDal.Add(question);
            return new SuccessResult(Messages.QuestionAdded);
        }

        public IResult Delete(Question question)
        {
            _questionDal.Delete(question);
            return new SuccessResult(Messages.QuestionDeletted);
        }

        public IDataResult<List<Question>> GetAll()
        {
            return new SuccessDataResult<List<Question>>(_questionDal.GetAll());

        }

        public IDataResult<Question> GetByQuestionId(int id)
        {
            return new SuccessDataResult<Question>(_questionDal.Get(c=>c.Id==id));
        }

        public IResult Update(Question question)
        {
            _questionDal.Update(question);
            return new SuccessResult(Messages.QuestionUpdated);
        }
    }
}
