using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.publishing.Application.Internal.OutboundServices.ACL;
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
    public class PromotionsController(
        IPromotionCommandService promotionCommandService,
        IPromotionQueryService promotionQueryService,
        ICommunityQueryService communityQueryService, 
        ITallerQueryService tallerQueryService,
        ExternalProfileService externalProfileService)
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

        [HttpGet("{PromocionId:int}")]
        [SwaggerOperation(
            Summary = "Gets a promotion by id",
            Description = "Gets a promotion for a given identifier",
            OperationId = "GetpromotionById"
        )]
        [SwaggerResponse(200, "The promotion was found")]
        public async Task<IActionResult> GetPromotionById([FromRoute] int PromocionId)
        {
            var prmotion = await promotionQueryService.Handle(new GetPromotionByIdQuery(PromocionId));
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


            // Obtener la entidad Community correspondiente al id proporcionado
            var community = await communityQueryService.Handle(new GetCommunityByIdQuery(promotion.ComunidadId));
            if (community is null) return BadRequest("No se pudo encontrar la comunidad correspondiente.");

            // Obtener la entidad Taller correspondiente al id proporcionado
            var taller = await tallerQueryService.Handle(new GetTallerByIdQuery(promotion.TallerId));
            if (taller is null) return BadRequest("No se pudo encontrar el taller correspondiente.");

            // Obtener la entidad Usuario correspondiente al id proporcionado
            var profile = await externalProfileService.FetchProfileById(promotion.Taller.UsuarioId);
            if (profile is null) return BadRequest("No se pudo encontrar el usuario correspondiente.");
            // Asociar las entidades Community y Taller con la nueva promoción
            promotion.Comunidad = community;
            promotion.Taller = taller;
            promotion.Taller.Usuario = profile;


            // Convertir la nueva promoción a un recurso para la respuesta
            var resource = PromotionResourceFromEntityAssembler.ToResourceFromEntity(promotion);
            // Devolver la respuesta con el recurso de la promoción creada

            return CreatedAtAction(nameof(GetPromotionById), new { PromocionId = resource.PromocionId }, resource);
        }
    }
    
}
