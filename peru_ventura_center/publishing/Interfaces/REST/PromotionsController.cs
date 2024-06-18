using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.publishing.Domain.Model.Queries;
using peru_ventura_center.publishing.Domain.Services;
using peru_ventura_center.publishing.Interfaces.REST.Resources;
using peru_ventura_center.publishing.Interfaces.REST.Transformers;
using peru_ventura_center.Publishing.Application.Internal.OutboundServices.ACL;
using peru_ventura_center.Publishing.Domain.Model.Queries;
using peru_ventura_center.Publishing.Domain.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace peru_ventura_center.publishing.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class PromotionsController(
        IPromotionCommandService promotionCommandService,
        IPromotionQueryService promotionQueryService, IDestinationTripQueryServices destinationTripQueryServices,ExternalFeedbackService externalIFeedbackService)
        : ControllerBase
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

        [HttpGet("{PromotionId:int}")]
        [SwaggerOperation(
            Summary = "Gets a promotion by id",
            Description = "Gets a promotion for a given identifier",
            OperationId = "GetpromotionById"
        )]
        [SwaggerResponse(200, "The promotion was found")]
        public async Task<IActionResult> GetPromotionById([FromRoute] int PromotionId)
        {
            var prmotion = await promotionQueryService.Handle(new GetPromotionByIdQueryQuery(PromotionId));
            if (prmotion is null) return NotFound();
            var resource = PromotionResourceFromEntityAssembler.ToResourceFromEntity(prmotion);
            return Ok(resource);
        }


        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates Promotions",
            Description = "Creates a promotion with a given data",
            OperationId = "CreatePromotion"
        )]
        [SwaggerResponse(201, "The promotion was created")]
        public async Task<IActionResult> CreatePromotion([FromBody] CreatePromotionResource createPromotionResource)
        {
            var createPromotionCommand = CreatePromotionCommandFromResourceAssembler.ToCommandFromResource(createPromotionResource);
            var promotion = await promotionCommandService.Handle(createPromotionCommand);
            if (promotion is null) return BadRequest();


            var destinationTrip = await destinationTripQueryServices.Handle(new GetDestinationTripByIdQuery(promotion.DestinationTripId));
            if (destinationTrip is null) return BadRequest("No se pudo encontrar el destino de viaje correspondiente.");

            var activity = await externalIFeedbackService.FetchActivityById(promotion.DestinationTrip.ActivityId);
            if (activity is null) return BadRequest("No se pudo encontrar la actividad correspondiente.");

         
            promotion.DestinationTrip = destinationTrip;
            promotion.DestinationTrip.Activity = activity;


            // Convertir la nueva promoción a un recurso para la respuesta
            var resource = PromotionResourceFromEntityAssembler.ToResourceFromEntity(promotion);
            // Devolver la respuesta con el recurso de la promoción creada

            return CreatedAtAction(nameof(GetPromotionById), new { PromotionId = resource.PromotionId }, resource);
        }
    }
    
}
