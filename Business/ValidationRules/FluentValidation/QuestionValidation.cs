using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class QuestionValidation:AbstractValidator<Question>
    {
        public QuestionValidation()
        {
           RuleFor(q=>q.Description).MinimumLength(2).MaximumLength(200);
            RuleFor(q => q.Description).NotEmpty();
            RuleFor(q => q.CategoryId).NotEmpty();
           
        }
    }
}
