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
                             where q.QuestionId == id
                             select new QuestionDetailDto
                             {
                                 QuestionId = q.QuestionId,
                                 Title = q.Title,
                                 QuestionDescription = q.Description,
                                 Comment = context.Comments.Where(cm => cm.CommentId == q.CommentId).ToList(),
                                 QuestionImage = context.QuestionImage.Where(qi=>qi.QuestıonId==q.QuestionId).ToList()
                             };
                return result.FirstOrDefault();
            }
        }

       
    }
}
