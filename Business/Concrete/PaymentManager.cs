using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal=paymentDal; 
        }
        public IResult Add(Payment payment)
        {
          var result =  BusinessRules.Run(IfUsersPaymentAlreadyExists(payment.UserId));
            if (result != null)
            {
                return result;
            }
            _paymentDal.Add(payment);
            return new SuccessResult();
        }
        

        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll());
        }

        public IDataResult<Payment> GetByUserId(int id)
        {
            return new SuccessDataResult<Payment>(_paymentDal.Get(c => c.UserId == id));
        }

        public IResult Update(Payment payment)
        {
           _paymentDal.Update(payment);
            return new SuccessResult();
        }

        private IResult IfUsersPaymentAlreadyExists(int userId)
        {
                var result = _paymentDal.GetAll(p=>p.UserId == userId).Any();

                if (result)
                {
                    return new ErrorResult();
                }
                return new SuccessResult();
            
        }
    }
}
