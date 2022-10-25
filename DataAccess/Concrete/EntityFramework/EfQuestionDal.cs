using Core.DataAccess.EntityRepository;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfQuestionDal : EfEntityRepositoryBase<Question, YazSınamaContext>, IQuestionDal
    {
        public QuestionDetailDto GetQuestionDetails(int id)
        {
            using (var context=new YazSınamaContext())
            {
                var result = from q in context.Questions
                             join c in context.Categories
                             on q.CategoryId equals c.Id
                             where q.Id==id
                             select new QuestionDetailDto
                             { 
                                 QuestionId = q.Id,
                                 Title=q.Title,
                                 QuestionDescription = q.Description,
                                 CategoryName = c.CategoryName,
                                 QuestionImage = context.QuestionImage.Where(qi=>qi.QuestıonId==q.Id).ToList()
                             };
                return result.FirstOrDefault();
            }
        }

       
    }
}
