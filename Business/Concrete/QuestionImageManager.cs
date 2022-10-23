using Core.Utilities.Helpers.FileHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
namespace Business.Concrete
{
    public class QuestionImageManager
    {
        IQuestionImageDal _questionImage;
        IFileHelper _fileHelper;
        public QuestionImageManager(IQuestionImageDal questionImage, IFileHelper fileHelper)
        {
            _questionImage = questionImage;
            _fileHelper = fileHelper;
        }

    }
}
