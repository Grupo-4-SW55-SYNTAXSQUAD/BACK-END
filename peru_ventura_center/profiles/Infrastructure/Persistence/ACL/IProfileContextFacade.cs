using peru_ventura_center.profiles.Domain.Model.Aggregates;

namespace peru_ventura_center.profiles.Infrastructure.Persistence.ACL
{
    public interface IProfileContextFacade
    {
        Task<int> CreateProfile(string nombre, string correoElectronico, string contrasenia, string ubicacion);
        Task<usuario?> FetchProfileById(int UsuarioId);
    }
}
