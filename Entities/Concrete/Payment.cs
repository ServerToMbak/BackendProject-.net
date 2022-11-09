using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CartNumber { get; set; }
        public string ExpertYear { get; set; }
        public string ExpertMonth { get; set; }
        public string CVV { get; set; }
        public string CardHolderFullName { get; set; }
        public decimal Balance { get; set; }
    }
}
