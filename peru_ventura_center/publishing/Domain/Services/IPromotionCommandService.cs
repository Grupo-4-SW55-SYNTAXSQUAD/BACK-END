using peru_ventura_center.publishing.Domain.Model.Commands;
using peru_ventura_center.Publishing.Domain.Model.Entities;

namespace peru_ventura_center.publishing.Domain.Services
{
    public interface IPromotionCommandService
    {
        Task<Promotion?> Handle(CreatePromotionCommand command);
    }
}
