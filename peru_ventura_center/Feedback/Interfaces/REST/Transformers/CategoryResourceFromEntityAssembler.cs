using peru_ventura_center.Feedback.Domain.Model.Aggregates;
using peru_ventura_center.Feedback.Interfaces.REST.Resources;

namespace peru_ventura_center.Feedback.Interfaces.REST.Transformers
{
    public static class CategoryResourceFromEntityAssembler
    {
        public static CategoryResource ToResourceFromEntity(Category category)
        {
            return new CategoryResource(category.CategoryId, category.TypeName);
        }
    }
}
