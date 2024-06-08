using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.publishing.Application.Internal.QueryServices;
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
    public class TallerController(ITallerQueryService tallerQueryService):ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
        Summary = "Gets all Talleres",
        Description = "Gets all Talleres",
        OperationId = "GetAllTalleres"
)]
        [SwaggerResponse(200, "Promotions found")]
        public async Task<IActionResult> GetAllTalleres()
        {
            var taller = await tallerQueryService.Handle(new GetAllTalleresQuery());//TODO: Implement GetAllPromotionsQuery
            var resource = taller.Select(TallerResourceFromEntityAssembler.ToResourceFromEntity);//
            return Ok(resource);
        }

        [HttpGet("{TallerId:int}")]
        [SwaggerOperation(
            Summary = "Gets a taller by id",
            Description = "Gets a taller for a given identifier",
            OperationId = "GetTallerById"
        )]
        [SwaggerResponse(200, "The promotion was found")]
        public async Task<IActionResult> GetTallerById([FromRoute] int TallerId)
        {
            var taller = await tallerQueryService.Handle(new GetTallerByIdQuery(TallerId));
            if (taller is null) return NotFound();
            var resource = TallerResourceFromEntityAssembler.ToResourceFromEntity(taller);
            return Ok(resource);
        }
    }
}
