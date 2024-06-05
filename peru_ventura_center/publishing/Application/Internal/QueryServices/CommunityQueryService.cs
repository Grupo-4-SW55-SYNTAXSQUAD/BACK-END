using peru_ventura_center.publishing.Domain.Model.Entities;
using peru_ventura_center.publishing.Domain.Model.Queries;
using peru_ventura_center.publishing.Domain.Repositories;
using peru_ventura_center.publishing.Domain.Services;

namespace peru_ventura_center.publishing.Application.Internal.QueryServices
{
    public class CommunityQueryService(ICommunityRepository communityRepository):ICommunityQueryService
    {
        public async Task<comunidad?> Handle(GetCommunityByIdQuery query)
        {
            return await communityRepository.FindByIdAsync(query.CommunityId);
        }
        public async Task<IEnumerable<comunidad>> Handle(GetAllCommunitiesQuery query)
        {
            return await communityRepository.ListAsync();
        }
    }
}
