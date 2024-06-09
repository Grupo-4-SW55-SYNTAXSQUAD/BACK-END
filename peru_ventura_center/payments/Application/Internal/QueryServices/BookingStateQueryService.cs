using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.payments.Domain.Model.Queries;
using peru_ventura_center.payments.Domain.Repositories;
using peru_ventura_center.payments.Domain.Services;

namespace peru_ventura_center.payments.Application.Internal.QueryServices
{
    public class BookingStateQueryService(IBookingStateRepository reservationStatus) : IBookingStateQueryService
    {
        public async Task<IEnumerable<BookingState>> Handle(GetAllBookingStateQuery query)
        {
            return await reservationStatus.ListAsync();
        }

        public async Task<BookingState?> Handle(GetBookingStateByIdQuery query)
        {
            return await reservationStatus.FindByIdAsync(query.id);
        }
    }
}
