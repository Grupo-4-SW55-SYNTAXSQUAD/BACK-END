using peru_ventura_center.profiles.Domain.Model.Commands;
using peru_ventura_center.profiles.Domain.Model.Entities;

namespace peru_ventura_center.profiles.Domain.Services
{
    public interface IUserCommandService
    {
        Task<User?> Handle(CreateUserCommand command);
        Task DeleteUser(int userId);

        Task PatchUser(int userId, Action<User> patchAction);
    }
}
