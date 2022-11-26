using Core.DataAccess.EntityRepository;
using Core.Entities;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
                             join user in context.Users
                             on q.UserId equals user.Id
                             where q.QuestionId == id

                             select new QuestionDetailDto
                             {

                                 userId = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Date = q.Date,
                                 QuestionId = q.QuestionId,
                                 Title = q.Title,
                                 QuestionDescription = q.Description,
                                 QuestionImage = context.QuestionImage.Where(qi => qi.QuestıonId == q.QuestionId).ToList(),
                                 Comment = (List<GetCommentDetailDto>)(
                               
                                 from comment in context.Comments.Where(cm => cm.QuestionId == q.QuestionId)
                                 from us in context.Users.Where(user=>user.Id ==comment.UserId)
                                           select new GetCommentDetailDto
                                           {
                                               UserId=comment.UserId,
                                               FirstName = us.FirstName,
                                               LastName = us.LastName,
                                               Date = comment.Date,
                                               TheComment = comment.TheComment
                                           })
         
                                   
                                 
                             };
                return result.FirstOrDefault();
            }
        }

       
    }
}
