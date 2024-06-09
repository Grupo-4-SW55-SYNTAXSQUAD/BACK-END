using peru_ventura_center.Publishing.Domain.Model.Entities;
using peru_ventura_center.Publishing.Domain.Model.Queries;
using peru_ventura_center.Publishing.Domain.Repositories;
using peru_ventura_center.Publishing.Domain.Services;

namespace peru_ventura_center.Publishing.Application.Internal.QueryServices
{
    public class CategoryQueryServices(ICategoryRepository categoryRepository) : ICategoryQueryService
    {
        public async Task<Category?> Handle(GetCategoryById query)
        {
            return await categoryRepository.FindByIdAsync(query.CategoryId);
        }
        public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query)
        {
            return await categoryRepository.ListAsync();
        }
    }
}
