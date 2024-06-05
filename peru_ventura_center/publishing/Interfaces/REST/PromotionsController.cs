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
    public class PromotionsController(
        IPromotionCommandService promotionCommandService,
        IPromotionQueryService promotionQueryService)
        :ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "Gets all Promotions",
            Description = "Gets all Promotions",
            OperationId = "GetAllPromotions"
        )]
        [SwaggerResponse(200, "Promotions found")] 
        public async Task<IActionResult> GetAllPromotions()
        {
            var promotions = await promotionQueryService.Handle(new GetAllPromotionsQuery());//TODO: Implement GetAllPromotionsQuery
            var resource = promotions.Select(PromotionResourceFromEntityAssembler.ToResourceFromEntity);//
            return Ok(resource);
        }
    }
}
