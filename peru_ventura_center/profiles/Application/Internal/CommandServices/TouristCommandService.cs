using peru_ventura_center.profiles.Domain.Model.Commands;
using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.profiles.Domain.Repositories;
using peru_ventura_center.profiles.Domain.Services;
using peru_ventura_center.Shared.Domain.Repositories;

namespace peru_ventura_center.profiles.Application.Internal.CommandServices
{
    public class TouristCommandService(ITouristRepository touristRepository, IUnitOfWork unitOfWork): ITouristCommandService
    {
        public async Task<Tourist?> Handle(CreateTouristCommand command)
        {
            var tourist = new Tourist(command);
            try
            {
                await touristRepository.AddAsync(tourist);
                await unitOfWork.CompleteAsync();
                return tourist;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while creating the tourist {e.Message}");
                return null;
            }
        }
    }
}
