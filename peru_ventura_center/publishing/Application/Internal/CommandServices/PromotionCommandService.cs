using peru_ventura_center.publishing.Domain.Model.Commands;
using peru_ventura_center.publishing.Domain.Repositories;
using peru_ventura_center.publishing.Domain.Services;
using peru_ventura_center.Publishing.Domain.Model.Commands;
using peru_ventura_center.Publishing.Domain.Model.Entities;
using peru_ventura_center.Shared.Domain.Repositories;

namespace peru_ventura_center.publishing.Application.Internal.CommandServices
{
    public class PromotionCommandService(IPromotionRepository promotionRepository, IUnitOfWork unitOfWork) : IPromotionCommandService
    {
        public async Task<Promotion?> Handle(CreatePromotionCommand command)
        {

            var promotion = new Promotion(command.DestinationTripId, command.Name, command.Description, command.Offer); // Create a new Promotion
            await promotionRepository.AddAsync(promotion); // Add the new Promotion to the repository
            await unitOfWork.CompleteAsync(); // Save the changes
            return promotion;
        }

        public async Task<Promotion?> Handle(DeletePromotionCommand command) { 


            var promotion = await promotionRepository.FindByIdAsync(command.DestinationTripId);

            if (promotion == null) {
                return null;
            }

            promotionRepository.Remove(promotion); // Delete the new Promotion to the repository
            await unitOfWork.CompleteAsync(); // Save the changes
            return promotion;
        }

        public async Task<Promotion?> Handle(PatchPromotionCommand command) {

            var promotion = await promotionRepository.FindByIdAsync(command.DestinationTripId);

            if (promotion == null){
                return null;
            }

            promotion.Name = command.name;
            promotionRepository.Update(promotion);
           
            await unitOfWork.CompleteAsync(); // Save the changes
            return promotion;
        }
    }
}
