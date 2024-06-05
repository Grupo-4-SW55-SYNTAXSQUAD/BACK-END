﻿using peru_ventura_center.publishing.Domain.Model.Entities;
using peru_ventura_center.publishing.Domain.Model.Queries;

namespace peru_ventura_center.publishing.Domain.Services
{
    public interface ICommunityQueryService
    {
        Task<comunidad?> Handle(GetCommunityByIdQuery query);
        Task<IEnumerable<comunidad>> Handle(GetAllCommunitiesQuery query);
    }
}
