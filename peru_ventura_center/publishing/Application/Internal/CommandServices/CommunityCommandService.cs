using peru_ventura_center.publishing.Domain.Model.Commands;
using peru_ventura_center.publishing.Domain.Model.Entities;
using peru_ventura_center.publishing.Domain.Repositories;
using peru_ventura_center.publishing.Domain.Services;
using peru_ventura_center.Shared.Domain.Repositories;

namespace peru_ventura_center.publishing.Application.Internal.CommandServices
{
    public class CommunityCommandService(ICommunityRepository communityRepository, IUnitOfWork unitOfWork):ICommunityCommandServcice
    {
        public async Task<comunidad?> Handle(CreateCommunitiyCommand command)
        {
            var community = new comunidad(command.nombre, command.descripcion, command.cultura); // Create a new Community
            await communityRepository.AddAsync(community); // Add the new Community to the repository
            await unitOfWork.CompleteAsync(); // Save the changes
            return community;
        }
    }
}
