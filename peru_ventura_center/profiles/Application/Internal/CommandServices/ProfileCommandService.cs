using peru_ventura_center.profiles.Domain.Model.Aggregates;
using peru_ventura_center.profiles.Domain.Model.Commands;
using peru_ventura_center.profiles.Domain.Repositories;
using peru_ventura_center.profiles.Domain.Services;
using peru_ventura_center.Shared.Domain.Repositories;

namespace LearningCenterPlatform.Profiles.Application.Internal.CommandServices
{
    public class ProfileCommandService(IProfileRepository profileRepository, IUnitOfWork unitOfWork) : IProfileCommandService
    {
        public async Task<usuario?> Handle(CreateProfileCommand command)
        {
            var profile = new usuario(command);
            try
            {
                await profileRepository.AddAsync(profile);
                await unitOfWork.CompleteAsync();
                return profile;
            }catch (Exception e)
            {
                Console.WriteLine($"An error occurred while creating the profile {e.Message}");
                return null;
            }
        }
    }
}
