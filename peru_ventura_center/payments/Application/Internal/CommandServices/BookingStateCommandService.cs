

using peru_ventura_center.payments.Domain.Model.Aggregates;
using peru_ventura_center.payments.Domain.Model.Commands;
using peru_ventura_center.payments.Domain.Repositories;
using peru_ventura_center.payments.Domain.Services;
using peru_ventura_center.Shared.Domain.Repositories;

namespace peru_ventura_center.payments.Application.Internal.CommandServices
{
    public class BookingStateCommandService(IBookingStateRepository bookingStateRepository, IUnitOfWork unitOfWork) : IBookingStateCommandService
    {
        public async Task<BookingState?> Handle(CreateBookingStateCommand command)
        {
            var bookingStateDate = new BookingState(command);
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
