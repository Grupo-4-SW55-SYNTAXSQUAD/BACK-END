using peru_ventura_center.Publishing.Domain.Model.Entities;
using peru_ventura_center.Publishing.Domain.Model.Queries;
using peru_ventura_center.Publishing.Domain.Repositories;
using peru_ventura_center.Publishing.Domain.Services;

namespace peru_ventura_center.Publishing.Application.Internal.QueryServices
{
    public class DestinationTripQueryServices(IDestinationTripRepository destinationTripRepository) : IDestinationTripQueryServices
    {
        public async Task<DestinationTrip?> Handle(GetDestinationTripByIdQuery query)
        {
            return await destinationTripRepository.FindByIdAsync(query.DestinationTripId);
        }
        public async Task<IEnumerable<DestinationTrip>> Handle(GetAllDestinationTripsQuery query)
        {
            return await destinationTripRepository.ListAsync();
        }
    }
}
