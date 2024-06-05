using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.publishing.Domain.Model.Queries;
using peru_ventura_center.publishing.Domain.Services;
using peru_ventura_center.publishing.Interfaces.REST.Transformers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace peru_ventura_center.publishing.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class CommunityController(ICommunityQueryService communityQueryService):ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
        Summary = "Gets all Communities",
        Description = "Gets all Communities",
        OperationId = "GetAllCommunities"
)]
        [SwaggerResponse(200, "Promotions found")]
        public async Task<IActionResult> GetAllPromotions()
        {
            var communities = await communityQueryService.Handle(new GetAllCommunitiesQuery());//TODO: Implement GetAllPromotionsQuery
            var resource = communities.Select(CommunityResourceFromEntityAssembler.ToResourceFromEntity);//
            return Ok(resource);
        }
    }
}
