using peru_ventura_center.Feedback.Domain.Model.Aggregates;
using peru_ventura_center.Feedback.Domain.Model.Queries;

namespace peru_ventura_center.Feedback.Domain.Services
{
    public interface ICategoryQueryService
    {
        Task<Category?> Handle(GetCategoryById query);
        Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query);
    }
}
