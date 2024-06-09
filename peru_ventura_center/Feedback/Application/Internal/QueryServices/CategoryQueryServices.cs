using peru_ventura_center.Feedback.Domain.Model.Aggregates;
using peru_ventura_center.Feedback.Domain.Model.Queries;
using peru_ventura_center.Feedback.Domain.Repositories;
using peru_ventura_center.Feedback.Domain.Services;

namespace peru_ventura_center.Feedback.Application.Internal.QueryServices
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
