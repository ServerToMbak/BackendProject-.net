using Core.DataAccess.EntityRepository;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfQuestionDal : EfEntityRepositoryBase<Question, YazSınamaContext>, IQuestionDal
    {
        public List<QuestionDetailDto> GetQuestionDetails()
        {
            using (var context=new YazSınamaContext())
            {
                var result = from q in context.Questions
                             join c in context.Categories
                             on q.CategoryId equals c.Id
                             select new QuestionDetailDto
                             {
                                 QuestionId = q.Id,
                                 QuestionDescription = q.Description,
                                 CategoryName = c.CategoryName
                             };
                return result.ToList();
            }
        }
    }
}
