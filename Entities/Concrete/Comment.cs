using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        public int CommentId { get; set; }
        public string TheComment { get; set; }
        public int QuestionId { get; set; }
    }
}
