using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Model.Commands;
using peru_ventura_center.Payments.Domain.Model.Queries;
using peru_ventura_center.Payments.Domain.Services;


namespace peru_ventura_center.Payments.Infrastructure.Persistence.ACL.Services
{
    public class PaymentContextFacade(IBookingCommandServices bookingCommandService, IBookingQueryServices bookingQueryService) : IPaymentContextFacade
    {
        public async Task<int> CreateBooking(DateTime BookingDate, int ActivityId, int BookingStateId)
        {
            var createBookingCommand = new CreateBookingCommand(BookingDate, ActivityId, BookingStateId);
            var booking = await bookingCommandService.Handle(createBookingCommand);
            return booking?.BookingId ?? 0;
        }

        public async Task<Booking?> FetchBookingById(int id)
        {
            var getBookingByIdQuery = new GetBookingByIdQuery(id);
            var booking = await bookingQueryService.Handle(getBookingByIdQuery);
            return booking;
        }

        public Task<Booking?> FetchBookingById(int? booking_id)
        {
            throw new NotImplementedException();
        }
    }
}
