using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class QuestionImage : IEntity
    {
        public int Id { get; set; }
        public int QuestıonId { get; set; }
        public string? ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
