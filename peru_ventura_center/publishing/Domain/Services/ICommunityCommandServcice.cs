using peru_ventura_center.publishing.Domain.Model.Commands;
using peru_ventura_center.publishing.Domain.Model.Entities;

namespace peru_ventura_center.publishing.Domain.Services
{
    public interface ICommunityCommandServcice
    {
        Task<comunidad?> Handle(CreateCommunitiyCommand command);
    }
}
