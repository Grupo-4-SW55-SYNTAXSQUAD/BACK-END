

using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.payments.Domain.Model.Commands;
using peru_ventura_center.payments.Domain.Repositories;
using peru_ventura_center.payments.Domain.Services;
using peru_ventura_center.Shared.Domain.Repositories;

namespace peru_ventura_center.payments.Application.Internal.CommandServices
{
    public class BookingStateCommandService(IBookingStateRepository bookingRepository, IUnitOfWork unitOfWork) : IBookingStateCommandService
    {
        public async Task<BookingState?> Handle(CreateBookingStateCommand command)
        {
            var bookingStateData = new BookingState(command);
            try
            {
                await bookingRepository.AddAsync(bookingStateData);
                await unitOfWork.CompleteAsync();
                return bookingStateData;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while creating the data {e.Message}");
                return null;
            }
        }
    }
}
