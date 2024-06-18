using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.profiles.Application.Internal.OutboundServices.ACL;
using peru_ventura_center.profiles.Domain.Model.Queries;
using peru_ventura_center.profiles.Domain.Services;
using peru_ventura_center.profiles.Interfaces.REST.Resources;
using peru_ventura_center.profiles.Interfaces.REST.Transformers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace peru_ventura_center.profiles.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class OwnerController : ControllerBase
    {
        private readonly IUserQueryService _profileQueryService;
        private readonly ExternalPublishingService _externalPublishingService;
        private readonly IOwnerCommandService _ownerCommandService;
        private readonly IOwnerQueryService _ownerQueryService; 

        public OwnerController(IUserQueryService profileQueryService, ExternalPublishingService externalPublishingService, IOwnerCommandService ownerCommandService, IOwnerQueryService ownerQueryService)
        {
            _profileQueryService = profileQueryService;
            _externalPublishingService = externalPublishingService;
            _ownerCommandService = ownerCommandService;
            _ownerQueryService = ownerQueryService;
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates Owner",
            Description = "Creates a owner with a given data",
            OperationId = "CreateOwner"
        )]
        [SwaggerResponse(201, "The owner was created")]
        [SwaggerResponse(400, "Invalid data provided for creating the owner")]
        [SwaggerResponse(500, "An error occurred while creating the owner")]
        public async Task<IActionResult> CreateOwner([FromBody] CreateOwnerResource createOwnerResource)
        {
            var createOwnerCommand = CreateOwnerCommandFromResourceAssembler.ToCommandFromResource(createOwnerResource);
            var owner = await _ownerCommandService.Handle(createOwnerCommand);
            if(owner is null) return BadRequest();

            var user = await _profileQueryService.Handle(new GetUserByIdQuery(owner.UserId));
            if (user is null) return BadRequest();

            var promotion = await _externalPublishingService.FetchPromotionById(owner.PromotionId);
            if (promotion is null) return BadRequest();

            owner.User = user;
            owner.Promotion = promotion;

            var resource = OwnerResourceFromEntityAssembler.ToResourceFromEntity(owner);
            return CreatedAtAction(nameof(GetOwnerById), new { ownerId = owner.OwnerId }, resource);
        }

        [HttpGet("{OwnerId:int}")]
        [SwaggerOperation(
            Summary = "Gets a owner by a user id",
            Description = "Gets a user owner for a given identifier",
            OperationId = "GetOwnerByUserId"
        )]
        [SwaggerResponse(200, "The owner was found")]
        [SwaggerResponse(404, "The owner was not found")]
        [SwaggerResponse(500, "An error occurred while processing the request")]
        public async Task<IActionResult> GetOwnerById([FromRoute] int OwnerId)
        {
            var owner = await _ownerQueryService.Handle(new GetOwnerByIdQuery(OwnerId));
            if (owner is null) return NotFound();
            var resource = OwnerResourceFromEntityAssembler.ToResourceFromEntity(owner);
            return Ok(resource);
        }
    }
}
