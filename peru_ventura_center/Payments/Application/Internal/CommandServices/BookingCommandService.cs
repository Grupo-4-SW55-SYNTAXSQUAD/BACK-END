using peru_ventura_center.Payments.Domain.Model.Aggregates;
using peru_ventura_center.Payments.Domain.Model.Commands;
using peru_ventura_center.Payments.Domain.Repositories;
using peru_ventura_center.Payments.Domain.Services;
using peru_ventura_center.Shared.Domain.Repositories;

namespace peru_ventura_center.Payments.Application.Internal.CommandServices
{
    public class BookingCommandService(IBookingRepository bookingRepository, IUnitOfWork unitOfWork):IBookingCommandServices
    {
        public async Task<Booking?> Handle(CreateBookingCommand command)
        {

            var booking = new Booking(command.BookingDate, command.ActivityId, command.BookingStateId);
            await bookingRepository.AddAsync(booking);
            await unitOfWork.CompleteAsync();
            return booking;
        }
    }
}
