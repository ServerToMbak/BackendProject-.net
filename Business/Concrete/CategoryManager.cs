using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
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
        //[SecuredOperation("admin")]
        [CacheRemoveAspect("ICategoryService.GetAll")]
        [CacheRemoveAspect("ICategoryService.GetById")]
        public IResult Add(Category category)
        {
            var result = BusinessRules.Run(IfCategoryNameAlreadyExist(category.CategoryName));
            if(result != null)
            {
                return result;
            }
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }
        [ValidationAspect(typeof(CategoryValidation))]
        [CacheRemoveAspect("ICategoryService.GetAll")]
        [CacheRemoveAspect("ICategoryService.GetById")]
        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult();
            
        }
        [CacheAspect(60)]
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }
        [CacheAspect(10)]
        public IDataResult<List<Category>> GetById(int id)
        {

            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(c=>c.CategoryId ==id));
        }
       
        public IDataResult<List<GetByCategoryAllitems>> GetCategoryDetail(int id)
        {
            return new SuccessDataResult<List<GetByCategoryAllitems>> (_categoryDal.getByCategoryDetails(id));
        }

        [ValidationAspect(typeof(CategoryValidation))]
        [CacheRemoveAspect("ICategoryService.GetAll")]
        [CacheRemoveAspect("ICategoryService.GetById")]
        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult();
        }
        private IResult IfCategoryNameAlreadyExist(string CategoryName)
        {
            var result = _categoryDal.GetAll(c => c.CategoryName==CategoryName).Any();
            
            if (result)
            {
                return new ErrorResult(Messages.CategoryAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
