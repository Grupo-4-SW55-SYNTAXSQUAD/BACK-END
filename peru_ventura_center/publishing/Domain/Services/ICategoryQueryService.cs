using peru_ventura_center.Publishing.Domain.Model.Entities;
using peru_ventura_center.Publishing.Domain.Model.Queries;

namespace peru_ventura_center.Publishing.Domain.Services
{
    public interface ICategoryQueryService
    {
        Task<Category?> Handle(GetCategoryById query);
        Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query);
    }
}
