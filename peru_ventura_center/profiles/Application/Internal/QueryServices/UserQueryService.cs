using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.profiles.Domain.Model.Queries;
using peru_ventura_center.profiles.Domain.Repositories;
using peru_ventura_center.profiles.Domain.Services;

namespace LearningCenterPlatform.Profiles.Application.Internal.QueryServices
{
    public class UserQueryService(IUserRepository profileRepository) : IUserQueryService
    {
        public async Task<IEnumerable<User>> Handle(GetAllProfilesQuery query)
        {
            return await profileRepository.ListAsync();
        }

        public async Task<User?> Handle(GetUserByEmailQuery query)
        {
            return await profileRepository.FindProfileByEmailAsync(query.Email);
        }

        public async Task<User?> Handle(GetUserByIdQuery query)
        {
            return await profileRepository.FindByIdAsync(query.UsuarioId);
        }

    }
}
