using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        public IResult Add(Category category);
        public IResult Delete(Category category);
        public IResult Update(Category category);
        public IDataResult<List<Category>> GetById(int id);
        public IDataResult<List<Category>> GetAll();
        public IDataResult<List<GetByCategoryAllitems>> GetCategoryDetail(int id);

    }
}