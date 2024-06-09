using peru_ventura_center.Publishing.Domain.Model.Commands;
using peru_ventura_center.Publishing.Domain.Model.Entities;

namespace peru_ventura_center.Publishing.Domain.Services
{
    public interface IReviewCommandServices
    {
        Task<Review?> Handle(CreateReviewCommand command);
    }
}
