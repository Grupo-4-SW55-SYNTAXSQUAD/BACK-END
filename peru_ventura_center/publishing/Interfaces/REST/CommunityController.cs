using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.publishing.Domain.Model.Queries;
using peru_ventura_center.publishing.Domain.Services;
using peru_ventura_center.publishing.Interfaces.REST.Resources;
using peru_ventura_center.publishing.Interfaces.REST.Transformers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace peru_ventura_center.publishing.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class CommunityController(ICommunityQueryService communityQueryService,ICommunityCommandServcice communityCommandServcice):ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
        Summary = "Gets all Communities",
        Description = "Gets all Communities",
        OperationId = "GetAllCommunities"
)]
        [SwaggerResponse(200, "Communities found")]
        public async Task<IActionResult> GetAllCommunities()
        {
            var communities = await communityQueryService.Handle(new GetAllCommunitiesQuery());//TODO: Implement GetAllPromotionsQuery
            var resource = communities.Select(CommunityResourceFromEntityAssembler.ToResourceFromEntity);//
            return Ok(resource);
        }

        [HttpGet("{ComunidadId:int}")]
        [SwaggerOperation(
             Summary = "Gets a community by id",
             Description = "Gets a community for a given identifier",
             OperationId = "GetCommunityById"
        )]
        [SwaggerResponse(200, "The community was found")]
        public async Task<IActionResult> GetCommunityById([FromRoute] int ComunidadId)
        {
            var community = await communityQueryService.Handle(new GetCommunityByIdQuery(ComunidadId));
            if (community is null) return NotFound();
            var resource = CommunityResourceFromEntityAssembler.ToResourceFromEntity(community);
            return Ok(resource);
        }
        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates Community",
            Description = "Creates a Community with a given data",
            OperationId = "CreateCommunity"
        )]
        [SwaggerResponse(201, "The Community was created")]
        public async Task<IActionResult> CreateCommunity([FromBody] CreateCommunityResource createCommunityResource)
        {
            var createCommunityCommand = CreateCommunityCommandFromResourceAssembler.ToCommandFromResource(createCommunityResource);
            var community = await communityCommandServcice.Handle(createCommunityCommand);
            if (community is null) return BadRequest();
            var resource = CommunityResourceFromEntityAssembler.ToResourceFromEntity(community);
            return CreatedAtAction(nameof(GetCommunityById), new { ComunidadId = resource.ComunidadId }, resource); 
        }
    }
}
