using Core.Utilities.Helpers.FileHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Entities.Concrete;

namespace Business.Concrete
{
    public class QuestionImageManager :IQuestionImageSevice
    {
        IQuestionImageDal _questionImage;
        IFileHelper _fileHelper;
        public QuestionImageManager(IQuestionImageDal questionImage, IFileHelper fileHelper)
        {
            _questionImage = questionImage;
            _fileHelper = fileHelper;
        }
        public IResult Add(IFormFile file, QuestionImage questionImage)
        {
            
            questionImage.ImagePath = _fileHelper.Upload(file, Messages.ImagesPath);
            questionImage.Date = DateTime.Now;
            _questionImage.Add(questionImage);
            return new SuccessResult("Resim başarıyla yüklendi");
        }
        public IResult Delete(QuestionImage questionImage)
        {
            _fileHelper.Delete(Messages.ImagesPath + questionImage.ImagePath);
            _questionImage.Delete(questionImage);
            return new SuccessResult();
        }
        public IResult Update(IFormFile file, QuestionImage questionImage)
        {
            questionImage.ImagePath = _fileHelper.Update(file, Messages.ImagesPath + questionImage.ImagePath, Messages.ImagesPath);
            _questionImage.Update(questionImage);
            return new SuccessResult();
        }

        public IDataResult<List<QuestionImage>> GetByQuestionId(int Id)
        {
            return new SuccessDataResult<List<QuestionImage>>(_questionImage.GetAll(c => c.QuestıonId == Id));
        }

        public IDataResult<QuestionImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<QuestionImage>(_questionImage.Get(c => c.Id == imageId));
        }

        public IDataResult<List<QuestionImage>> GetAll()
        {
            return new SuccessDataResult<List<QuestionImage>>(_questionImage.GetAll());
        }
       

    }
}
