using Core.Entities;

namespace Entities.Concrete
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}