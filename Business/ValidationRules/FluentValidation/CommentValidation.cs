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
            RuleFor(c => c.TheComment).MaximumLength(400);
            RuleFor(c=>c.TheComment).MinimumLength(2);
            RuleFor(c=>c.TheComment).NotEmpty();
        }
    }
}
