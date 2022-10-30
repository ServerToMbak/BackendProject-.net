using Core.DataAccess;
using Core.DataAccess.EntityRepository;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, YazSınamaContext>, ICategoryDal
    {
        public List<GetByCategoryAllitems> getByCategoryDetails(int id)
        {
            using (var context=new YazSınamaContext())
            {
                var result = from c in context.Categories
                             join q in context.Questions
                             on c.CategoryId equals q.CategoryId
                             join cm in context.Comments
                             on q.QuestionId equals cm.QuestionId
                             where c.CategoryId==id
                             select new GetByCategoryAllitems
                             {
                                 QuestionId = q.QuestionId ,
                                 Description = q.Description  ,
                                 CategoryId = c.CategoryId,
                                 Title = q.Title,
                                 CommentId = cm.CommentId,
                                 UserId = q.UserId,
                                 CategoryName = c.CategoryName ,
                                 TheComment = cm.TheComment ,
                                 QuestionImage = context.QuestionImage.Where(qi=>qi.QuestıonId==q.QuestionId).ToList()
                             };
                return result.ToList();
            }
        }
    }
}
