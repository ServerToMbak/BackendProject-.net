using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
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
        IQuestionImageSevice _questionImageService;
        public QuestionManager(IQuestionDal questionDal,ICommentServcie commentServcie, IQuestionImageSevice questionImageService)
        {
            _questionDal = questionDal;
            _commentServcie = commentServcie;
            _questionImageService = questionImageService;   
        }

        public IDataResult<int> CountNumberOfQuestionInCategory(int categoryId) 
        {
            return new SuccessDataResult<int>(_questionDal.GetAll(q=>q.CategoryId== categoryId).Count());
        }

        [ValidationAspect(typeof(QuestionValidation))]
        [CacheRemoveAspect("IQestionService.add")]
        [CacheRemoveAspect("IQestionService.GetAll")]
        public IResult Add(Question question)
        {
            question.Date = DateTime.Now;
            _questionDal.Add(question);
            return new SuccessResult(Messages.QuestionAdded);
        }
        [CacheRemoveAspect("IQestionService.add")]
        [CacheRemoveAspect("IQestionService.GetAll")]
        public IResult Delete(Question question)
        {
            _questionDal.Delete(question);
            _commentServcie.DeleteAllCommentByQuestionId(question.QuestionId);
            _questionImageService.DeleteAllImagesByQuestionId(question.QuestionId);
            return new SuccessResult(Messages.QuestionDeletted);
        }
        [CacheAspect(10)]
        public IDataResult<List<Question>> GetAll()
        {
            return new SuccessDataResult<List<Question>>(_questionDal.GetAll());

        }
        [CacheAspect(10)]
        public IDataResult<List<Question>> GetByCategoryId(int id)
        {
            return new SuccessDataResult<List<Question>>(_questionDal.GetAll(q=>q.CategoryId==id));
        }

        public IDataResult<Question> GetByQuestionId(int id)
        {
            return new SuccessDataResult<Question>(_questionDal.Get(c=>c.QuestionId ==id));
        }

        public IDataResult<QuestionDetailDto> GetQuestionDetails(int questionId)
        {
            var result = _commentServcie.GetCommentDetail(questionId);
            if (result == null)
            {
               
            }
           return new SuccessDataResult<QuestionDetailDto>(_questionDal.GetQuestionDetails(questionId));
        }
        [CacheRemoveAspect("IQestionService.add")]
        [CacheRemoveAspect("IQestionService.GetAll")]
        public IResult Update(Question question)
        {
            _questionDal.Update(question);
            return new SuccessResult(Messages.QuestionUpdated);
        }
    }
}
