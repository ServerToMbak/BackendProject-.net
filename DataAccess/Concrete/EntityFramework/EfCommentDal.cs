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
    public class EfCommentDal : EfEntityRepositoryBase<Comment,YazSınamaContext>, ICommentDal
    {

        public GetCommentDetailDto GetCommentDetail(int Questionid)
        {
            using (var context = new YazSınamaContext())
            {
                var result = from q in context.Questions
                             join c in context.Comments
                             on q.QuestionId equals c.QuestionId
                             join u in context.Users 
                             on c.UserId equals u.Id
                             where q.QuestionId == Questionid
                             select new GetCommentDetailDto
                             {
                                 UserId = c.UserId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Date =c.Date,
                                 TheComment = c.TheComment
                             };
                return result.FirstOrDefault();
            }
        }



    }
}
