using peru_ventura_center.profiles.Domain.Model.Commands;
using peru_ventura_center.profiles.Domain.Model.Entities;
using peru_ventura_center.profiles.Domain.Repositories;
using peru_ventura_center.profiles.Domain.Services;
using peru_ventura_center.Shared.Domain.Repositories;

namespace peru_ventura_center.profiles.Application.Internal.CommandServices
{
    public class OwnerCommandService(IOwnerReposirory ownerReposirory, IUnitOfWork unitOfWork):IOwnerCommandService
    {
        public async Task<Owner?> Handle(CreateOwnerCommand command)
        {
            var owner = new Owner(command);
            try
            {
                await ownerReposirory.AddAsync(owner);
                await unitOfWork.CompleteAsync();
                return owner;
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while creating the owner {e.Message}");
                return null;
            }
        }
    }
}
