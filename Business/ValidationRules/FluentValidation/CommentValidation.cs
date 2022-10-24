using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CommentValidation:AbstractValidator<Comment>
    {
        public CommentValidation()
        {
            RuleFor(c => c.Description).MaximumLength(200);
            RuleFor(c=>c.Description).MinimumLength(2);
            RuleFor(c=>c.Description).NotEmpty();
        }
    }
}
