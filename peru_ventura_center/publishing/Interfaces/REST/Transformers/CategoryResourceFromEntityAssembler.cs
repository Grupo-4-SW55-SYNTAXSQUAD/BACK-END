using peru_ventura_center.Publishing.Domain.Model.Entities;
using peru_ventura_center.Publishing.Interfaces.REST.Resources;

namespace peru_ventura_center.Publishing.Interfaces.REST.Transformers
{
    public static class CategoryResourceFromEntityAssembler
    {
        public static CategoryResource ToResourceFromEntity(Category category)
        {
            return new CategoryResource(category.CategoryId, category.TypeName);
        }
    }
}
