using peru_ventura_center.publishing.Domain.Model.Aggregates;
using peru_ventura_center.publishing.Domain.Model.Commands;

namespace peru_ventura_center.publishing.Domain.Services
{
    public interface IPromotionCommandService
    {
        Task<promociones?> Handle(CreatePromotionCommand command);
    }
}
