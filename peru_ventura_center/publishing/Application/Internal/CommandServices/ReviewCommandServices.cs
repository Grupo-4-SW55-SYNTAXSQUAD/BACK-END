using peru_ventura_center.Publishing.Domain.Model.Commands;
using peru_ventura_center.Publishing.Domain.Model.Entities;
using peru_ventura_center.Publishing.Domain.Repositories;
using peru_ventura_center.Publishing.Domain.Services;
using peru_ventura_center.Shared.Domain.Repositories;

namespace peru_ventura_center.Publishing.Application.Internal.CommandServices
{
    public class ReviewCommandServices(IReviewRepository reviewRepository, IUnitOfWork unitOfWork):IReviewCommandServices
    {
        public async Task<Review?> Handle(CreateReviewCommand command)
        {

            var review = new Review(command.Score,command.Comment,command.ActivityId); // Create a new Review
            await reviewRepository.AddAsync(review); // Add the new Review to the repository
            await unitOfWork.CompleteAsync(); // Save the changes
            return review;
        }
    }
}
