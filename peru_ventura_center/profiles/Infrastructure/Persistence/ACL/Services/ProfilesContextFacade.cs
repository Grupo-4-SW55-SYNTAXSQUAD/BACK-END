using peru_ventura_center.profiles.Domain.Model.Aggregates;
using peru_ventura_center.profiles.Domain.Model.Commands;
using peru_ventura_center.profiles.Domain.Model.Queries;
using peru_ventura_center.profiles.Domain.Services;

namespace peru_ventura_center.profiles.Infrastructure.Persistence.ACL.Services
{
    public class ProfilesContextFacade(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService) : IProfileContextFacade
    {
        public async Task<int> CreateProfile(string nombre, string correoElectronico, string contrasenia, string ubicacion)
        {
            var createProfileCommand = new CreateProfileCommand(nombre, correoElectronico, contrasenia, ubicacion);
            var profile = await profileCommandService.Handle(createProfileCommand);
            return profile?.UsuarioId ?? 0;
        }

        public async Task<usuario?> FetchProfileById(int UsuarioId)
        {
            var getProfileByEmailQuery = new GetProfileByIdQuery(UsuarioId);
            var profile = await profileQueryService.Handle(getProfileByEmailQuery);
            return profile;
        }
    }
}
