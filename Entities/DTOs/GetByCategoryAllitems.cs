using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class GetByCategoryAllitems
    {
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string CategoryName { get; set; }
        public string TheComment { get; set; }
        public List<QuestionImage> QuestionImage { get; set; }
    }
}
