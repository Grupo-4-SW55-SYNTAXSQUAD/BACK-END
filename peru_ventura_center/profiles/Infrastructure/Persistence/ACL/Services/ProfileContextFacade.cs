using peru_ventura_center.profiles.Domain.Model.Commands;
using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.profiles.Domain.Model.Queries;
using peru_ventura_center.profiles.Domain.Services;

namespace peru_ventura_center.profiles.Infrastructure.Persistence.ACL.Services
{
    public class ProfileContextFacade(IUserCommandService profileCommandService, IUserQueryService profileQueryService) : IProfileContextFacade
    {
        public async Task<int> CreateProfile(string name, string email, string password, string phone, string userType)
        {
            var createProfileCommand = new CreateUserCommand(name,email,password,phone,userType);
            var profile = await profileCommandService.Handle(createProfileCommand);
            return profile?.UserId ?? 0;
        }

        public async Task<User?> FetchProfileById(int UsuarioId)
        {
            var getProfileByEmailQuery = new GetUserByIdQuery(UsuarioId);
            var profile = await profileQueryService.Handle(getProfileByEmailQuery);
            return profile;
        }
    }
}
