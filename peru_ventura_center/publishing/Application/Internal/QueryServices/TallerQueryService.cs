using peru_ventura_center.publishing.Domain.Model.Entities;
using peru_ventura_center.publishing.Domain.Model.Queries;
using peru_ventura_center.publishing.Domain.Repositories;
using peru_ventura_center.publishing.Domain.Services;

namespace peru_ventura_center.publishing.Application.Internal.QueryServices
{
    public class TallerQueryService(ITallerRepository tallerRepository): ITallerQueryService
    {
        public async Task<Taller?> Handle(GetTallerByIdQuery query)
        {
            return await tallerRepository.FindByIdAsync(query.TallerId);
        }
    }
}
