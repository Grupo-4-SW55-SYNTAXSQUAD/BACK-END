using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.payments.Domain.Model.Queries;
using peru_ventura_center.payments.Domain.Repositories;
using peru_ventura_center.payments.Domain.Services;

namespace peru_ventura_center.payments.Application.Internal.QueryServices
{
    public class BookingStateQueryService(IBookingStateRepository boookingRepository) : IBookingStateQueryService
    {
        public async Task<IEnumerable<BookingState>> Handle(GetAllBookingStateQuery query)
        {
            return await boookingRepository.ListAsync();
        }

        public async Task<BookingState?> Handle(GetBookingStateByIdQuery query)
        {
            return await boookingRepository.FindByIdAsync(query.booking_id);
        }
    }
}
