﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidation:AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(c=>c.CategoryName).NotEmpty();
            RuleFor(c => c.CategoryName).MinimumLength(2);
            RuleFor(c => c.CategoryName).MaximumLength(20);
        }
    }
}
