using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        public IResult Add(Payment payment);
        public IResult Delete(Payment payment);
        public IResult Update(Payment payment);
        public IDataResult<Payment> GetByUserId(int id);
        public IDataResult<List<Payment>> GetAll();
    }
}
