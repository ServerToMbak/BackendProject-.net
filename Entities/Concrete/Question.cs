using Core.Entities;

namespace Entities.Concrete
{
    public class Question : IEntity
    {
       
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}