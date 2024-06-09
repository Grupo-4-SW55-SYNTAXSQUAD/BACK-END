

using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.payments.Domain.Model.Commands;
using peru_ventura_center.payments.Domain.Repositories;
using peru_ventura_center.payments.Domain.Services;
using peru_ventura_center.Shared.Domain.Repositories;

namespace peru_ventura_center.payments.Application.Internal.CommandServices
{
    public class BookingCommandService(IBookingRepository bookingRepository, IUnitOfWork unitOfWork) : IBookingCommandService
    {
        public async Task<Booking?> Handle(CreateBookingCommand command)
        {
            var bookingData = new Booking(command);
            try
            {
                await bookingRepository.AddAsync(bookingData);
                await unitOfWork.CompleteAsync();
                return bookingData;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while creating the data {e.Message}");
                return null;
            }
        }
    }
}
