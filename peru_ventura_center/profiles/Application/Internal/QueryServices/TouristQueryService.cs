using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.profiles.Domain.Model.Queries;
using peru_ventura_center.profiles.Domain.Repositories;
using peru_ventura_center.profiles.Domain.Services;

namespace peru_ventura_center.profiles.Application.Internal.QueryServices
{
    public class TouristQueryService(ITouristRepository touristRepository):ITouristQueryService
    {
        public async Task<Tourist?> Handle(GetTouristByIdQuery query)
        {
            return await touristRepository.FindByIdAsync(query.UserId);
        }
    }
}
