using peru_ventura_center.publishing.Domain.Model.Commands;
using peru_ventura_center.publishing.Domain.Model.Queries;
using peru_ventura_center.publishing.Domain.Services;
using peru_ventura_center.Publishing.Domain.Model.Entities;
using peru_ventura_center.Publishing.Infrastructure.Persistence.ACL;

namespace peru_ventura_center.publishing.Infrastructure.Persistence.ACL.Services
{
    public class PublishingContextFacade(IPromotionCommandService promotionCommandService, IPromotionQueryService promotionQueryService) : IPublishingContextFacade
    {
        public async Task<int> CreatePromotion(int DestinationTripId,
        string Name,
        string Description,
        string Offer)
        {
            var createPomotionCommand = new CreatePromotionCommand(DestinationTripId,Name,Description,Offer);
            var promotion = await promotionCommandService.Handle(createPomotionCommand);
            return promotion?.PromotionId ?? 0;
        }

        public async Task<Promotion?> FetchPromotionById(int PromotionId)
        {
            var getPromotionByIdQuery = new GetPromotionByIdQueryQuery(PromotionId);
            var promotion = await promotionQueryService.Handle(getPromotionByIdQuery);
            return promotion;
        }

        public Task<Promotion?> FetchPromotionById(int? PromotionId)
        {
            throw new NotImplementedException();
        }
    }
}
