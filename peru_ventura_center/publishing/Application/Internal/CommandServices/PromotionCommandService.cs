using peru_ventura_center.publishing.Domain.Model.Aggregates;
using peru_ventura_center.publishing.Domain.Model.Commands;
using peru_ventura_center.publishing.Domain.Repositories;
using peru_ventura_center.publishing.Domain.Services;
using peru_ventura_center.Shared.Domain.Repositories;

namespace peru_ventura_center.publishing.Application.Internal.CommandServices
{
    public class PromotionCommandService(IPromotionRepository promotionRepository, IUnitOfWork unitOfWork):IPromotionCommandService
    {
        public async Task<promociones?> Handle(CreatePromotionCommand command)
        {
        
            var promotion = new promociones(command.name,command.description,command.idCommunity, command.idTaller,command.location,command.startDate,command.offer,command.price); // Create a new Promotion
            await promotionRepository.AddAsync(promotion); // Add the new Promotion to the repository
            await unitOfWork.CompleteAsync(); // Save the changes
            return promotion;
        }
    }
}
