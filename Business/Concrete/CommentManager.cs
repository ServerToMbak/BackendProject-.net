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
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager : ICommentServcie
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;   
        }
        [ValidationAspect(typeof(CommentValidation))]
        public IResult Add(Comment comment)
        {
            comment.Date = DateTime.Now;
            _commentDal.Add(comment);
            return new SuccessResult(Messages.CommentAdded);
        }

        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.CommentDeleted);
        }

        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll());
        }

        public IDataResult<Comment> GetByCommentId(int id)
        {
            return new SuccessDataResult<Comment>(_commentDal.Get(c=>c.CommentId==id));
        }

        public IDataResult<GetCommentDetailDto> GetCommentDetail(int id)
        {
            return new SuccessDataResult<GetCommentDetailDto>(_commentDal.GetCommentDetail(id));
        }

        [ValidationAspect(typeof(CommentValidation))]
        public IResult Update(Comment comment)
        {
            _commentDal.Update(comment);
            return new SuccessResult(Messages.CommentUpdated);
        }
    }
}
