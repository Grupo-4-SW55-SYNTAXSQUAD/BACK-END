
using peru_ventura_center.profiles.Domain.Model.Aggregates;
using peru_ventura_center.profiles.Infrastructure.Persistence.ACL;
using peru_ventura_center.publishing.Domain.Model.ValueObjects;

namespace peru_ventura_center.publishing.Application.Internal.OutboundServices.ACL
{
    public class ExternalProfileService(IProfileContextFacade profileContextFacade)
    {
        public async Task<usuario?> FetchProfileById(int UsuarioId)
        {
            var profileId = await profileContextFacade.FetchProfileById(UsuarioId);
            if (profileId == null) return await Task.FromResult<usuario?>(null);
            return profileId;
        }
        public async Task<ProfileId?> CreateProfile(string nombre, string correoElectronico, string contrasenia, string ubicacion)
        {
            var profileId = await profileContextFacade.CreateProfile(nombre, correoElectronico, contrasenia, ubicacion);
            if (profileId == 0) return await Task.FromResult<ProfileId?>(null);
            return new ProfileId(profileId);
        }
    }
}
