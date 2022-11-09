using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IQuestionImageSevice
    {
        IResult Add(IFormFile file, QuestionImage questionImage);
        IResult Delete(QuestionImage questionImage);
        IResult Update(IFormFile file, QuestionImage questionImage);

        IDataResult<List<QuestionImage>> GetAll();
        IDataResult<List<QuestionImage>> GetByQuestionId(int QuestinId);
        IDataResult<QuestionImage> GetByImageId(int QuestinId);
        IResult DeleteAllImagesByQuestionId(int questionId); 
    }
}
