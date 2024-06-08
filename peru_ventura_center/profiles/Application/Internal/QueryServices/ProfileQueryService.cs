using peru_ventura_center.profiles.Domain.Model.Aggregates;
using peru_ventura_center.profiles.Domain.Model.Queries;
using peru_ventura_center.profiles.Domain.Repositories;
using peru_ventura_center.profiles.Domain.Services;

namespace LearningCenterPlatform.Profiles.Application.Internal.QueryServices
{
    public class ProfileQueryService(IProfileRepository profileRepository) : IProfileQueryService
    {
        public async Task<IEnumerable<usuario>> Handle(GetAllProfilesQuery query)
        {
            return await profileRepository.ListAsync();
        }

        public async Task<usuario?> Handle(GetProfileByEmailQuery query)
        {
            return await profileRepository.FindProfileByEmailAsync(query.Email);
        }

        public async Task<usuario?> Handle(GetProfileByIdQuery query)
        {
            return await profileRepository.FindByIdAsync(query.UsuarioId);
        }
    }
}
