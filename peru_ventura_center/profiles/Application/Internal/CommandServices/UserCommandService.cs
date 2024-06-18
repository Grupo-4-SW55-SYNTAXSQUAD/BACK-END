using peru_ventura_center.profiles.Domain.Model.Commands;
using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.profiles.Domain.Model.ValueObjects;
using peru_ventura_center.profiles.Domain.Repositories;
using peru_ventura_center.profiles.Domain.Services;
using peru_ventura_center.Shared.Domain.Repositories;

namespace LearningCenterPlatform.Profiles.Application.Internal.CommandServices
{
    public class UserCommandService(IUserRepository profileRepository, IUnitOfWork unitOfWork) : IUserCommandService
    {
        public async Task<User?> Handle(CreateUserCommand command)
        {
            

            var existingUser = await profileRepository.FindProfileByEmailAsync(command.email); 
            if (existingUser != null)
            {
                throw new InvalidOperationException("A request with the same email already exists.");
            }
            var user = new User(command);
            try
            {
                await profileRepository.AddAsync(user);
                await unitOfWork.CompleteAsync();
                return user;
            }catch (Exception e)
            {
                Console.WriteLine($"An error occurred while creating the profile {e.Message}");
                return null;
            }
        }

    }
}
