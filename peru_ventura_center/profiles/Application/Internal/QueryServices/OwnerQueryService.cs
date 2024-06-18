using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.profiles.Domain.Model.Queries;
using peru_ventura_center.profiles.Domain.Repositories;
using peru_ventura_center.profiles.Domain.Services;

namespace peru_ventura_center.profiles.Application.Internal.QueryServices
{
    public class OwnerQueryService(IOwnerReposirory ownerReposirory): IOwnerQueryService
    {
        public async Task<Owner?> Handle(GetOwnerByIdQuery query)
        {
            return await ownerReposirory.FindByIdAsync(query.OwnerId);
        }
    }
}
