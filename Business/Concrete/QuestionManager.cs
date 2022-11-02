using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;
        ICommentServcie _commentServcie;
        public QuestionManager(IQuestionDal questionDal,ICommentServcie commentServcie)
        {
            _questionDal = questionDal;
            _commentServcie=commentServcie;
    }
        [ValidationAspect(typeof(QuestionValidation))]
        public IResult Add(Question question)
        {
            question.Date = DateTime.Now;
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

        public IDataResult<List<Question>> GetByCategoryId(int id)
        {
            return new SuccessDataResult<List<Question>>(_questionDal.GetAll(q=>q.CategoryId==id));
        }

        public IDataResult<Question> GetByQuestionId(int id)
        {
            return new SuccessDataResult<Question>(_questionDal.Get(c=>c.CategoryId ==id));
        }

        public IDataResult<QuestionDetailDto> GetQuestionDetails(int questionId)
        {
            var result = _commentServcie.GetCommentDetail(questionId);
            if (result == null)
            {
               
            }
           return new SuccessDataResult<QuestionDetailDto>(_questionDal.GetQuestionDetails(questionId));
        }

        public IResult Update(Question question)
        {
            _questionDal.Update(question);
            return new SuccessResult(Messages.QuestionUpdated);
        }
    }
}
