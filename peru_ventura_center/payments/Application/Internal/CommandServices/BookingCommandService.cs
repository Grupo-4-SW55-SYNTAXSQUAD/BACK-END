

using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.payments.Domain.Model.Commands;
using peru_ventura_center.payments.Domain.Repositories;
using peru_ventura_center.payments.Domain.Services;
using peru_ventura_center.Shared.Domain.Repositories;

namespace peru_ventura_center.payments.Application.Internal.CommandServices
{
    public class BookingCommandService(IBookingRepository bookingStateRepository, IUnitOfWork unitOfWork) : IBookingCommandService
    {
        public async Task<Booking?> Handle(CreateBookingCommand command)
        {
            var bookingStateDate = new Booking(command);
            try
            {
                await bookingStateRepository.AddAsync(bookingStateDate);
                await unitOfWork.CompleteAsync();
                return bookingStateDate;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while creating the data {e.Message}");
                return null;
            }
        }
    }
}
