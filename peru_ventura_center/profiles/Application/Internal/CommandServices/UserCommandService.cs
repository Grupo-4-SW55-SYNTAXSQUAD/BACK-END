using LearningCenterPlatform.Profiles.Infraestructure.Persistence.EFC.Repositories;
using peru_ventura_center.profiles.Domain.Model.Commands;
using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.profiles.Domain.Repositories;
using peru_ventura_center.profiles.Domain.Services;
using peru_ventura_center.Shared.Domain.Repositories;

namespace LearningCenterPlatform.Profiles.Application.Internal.CommandServices
{
    public class UserCommandService(IUserRepository profileRepository, IUnitOfWork unitOfWork,IOwnerReposirory ownerReposirory, ITouristRepository touristRepository) : IUserCommandService
    {
        public async Task<User?> Handle(CreateUserCommand command)
        {


            var existingUser = await profileRepository.FindProfileByEmailAsync(command.email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("A user with the same email already exists.");
            }

            var user = new User(command);
            await profileRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();

            // Crear el tipo de usuario según el userType especificado
            if (command.userType == "tourist")
            {
                var tourist = new Tourist(user.UserId); 
                await touristRepository.AddAsync(tourist);
            }
            else if (command.userType == "owner")
            {
                var owner = new Owner(user.UserId); 
                await ownerReposirory.AddAsync(owner);
            }

            await unitOfWork.CompleteAsync();

            return user;

        }
        public async Task DeleteUser(int userId)
        {
            var user = await profileRepository.FindByIdAsync(userId);
            if (user != null)
            {
                await profileRepository.DeleteProfileAsync(user);
            }
            else
            {
                throw new ArgumentException("User not found.");
            }
        }
        public async Task PatchUser(int userId, Action<User> patchAction)
        {
            var user = await profileRepository.FindByIdAsync(userId);
            if (user == null)
                throw new ArgumentException("User not found.");

            patchAction(user);

            await profileRepository.UpdateProfileAsync(user); // Implementar método UpdateAsync en UserRepository
            await unitOfWork.CompleteAsync();
        }
    }
}
