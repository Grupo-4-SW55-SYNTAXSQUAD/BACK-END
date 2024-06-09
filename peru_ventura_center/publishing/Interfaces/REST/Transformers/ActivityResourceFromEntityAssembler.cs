using peru_ventura_center.Publishing.Domain.Model.Aggregates;
using peru_ventura_center.Publishing.Interfaces.REST.Resources;

namespace peru_ventura_center.Publishing.Interfaces.REST.Transformers
{
    public static class ActivityResourceFromEntityAssembler
    {
        public static ActivityResource ToResourceFromEntity(Activity activity)
        {
            return new ActivityResource(
                    activity.ActivityId,
                    activity.Name,
                    activity.Description,
                    activity.Schedule,
                    activity.MaxPeople,
                    activity.Cost,
                    CategoryResourceFromEntityAssembler.ToResourceFromEntity(activity.Category)

                );
        }
    }
}
