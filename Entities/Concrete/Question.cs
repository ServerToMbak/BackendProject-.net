using Core.Entities;

namespace Entities.Concrete
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
    }
}