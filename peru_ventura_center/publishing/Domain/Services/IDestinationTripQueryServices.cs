using peru_ventura_center.Publishing.Domain.Model.Entities;
using peru_ventura_center.Publishing.Domain.Model.Queries;

namespace peru_ventura_center.Publishing.Domain.Services
{
    public interface IDestinationTripQueryServices
    {
        Task<DestinationTrip?> Handle(GetDestinationTripById query);
        Task<IEnumerable<DestinationTrip>> Handle(GetAllDestinationTripsQuery query);
    }
}
