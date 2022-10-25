using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal CategporyDal)
        {
            _categoryDal = CategporyDal;
        }
       // [SecuredOperation("admin")]
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }
        [ValidationAspect(typeof(CategoryValidation))]
        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult();
            
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        public IDataResult<List<Category>> GetById(int id)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(c=>c.Id==id));
        }
        [ValidationAspect(typeof(CategoryValidation))]
        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult();
        }
    }
}
