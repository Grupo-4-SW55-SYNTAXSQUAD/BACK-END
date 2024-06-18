using peru_ventura_center.profiles.Domain.Model.Entities;

namespace peru_ventura_center.profiles.Infrastructure.Persistence.ACL
{
    public interface IProfileContextFacade
    {
        Task<int> CreateProfile(string name, string email, string password, string phone, string userType);
        Task<User?> FetchProfileById(int UsuarioId);
    }
}
