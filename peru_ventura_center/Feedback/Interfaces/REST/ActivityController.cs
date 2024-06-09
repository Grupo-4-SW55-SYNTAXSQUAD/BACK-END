using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.Feedback.Domain.Model.Queries;
using peru_ventura_center.Feedback.Domain.Services;
using peru_ventura_center.Feedback.Interfaces.REST.Resources;
using peru_ventura_center.Feedback.Interfaces.REST.Transformers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace peru_ventura_center.Feedback.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ActivityController(IActivityQueryServices activityQueryServices, IActivityCommandServices activityCommandServices, ICategoryQueryService categoryQueryService) : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "Gets all Activities",
            Description = "Gets all Activities",
            OperationId = "GetAllActivities"
        )]
        [SwaggerResponse(200, "Activities found")]
        public async Task<IActionResult> GetAllActivities()
        {
            var activities = await activityQueryServices.Handle(new GetAllActivitiesQuery());//TODO: Implement GetAllActivitiesQuery
            var resource = activities.Select(ActivityResourceFromEntityAssembler.ToResourceFromEntity);//
            return Ok(resource);
        }

        [HttpGet("{AcitivityId:int}")]
        [SwaggerOperation(
            Summary = "Gets a activity by id",
            Description = "Gets a activity for a given identifier",
            OperationId = "GetActivityById"
        )]
        [SwaggerResponse(200, "The activity was found")]
        public async Task<IActionResult> GetActivityById([FromRoute] int AcitivityId)
        {
            var activity = await activityQueryServices.Handle(new GetActivityByIdQuery(AcitivityId));
            if (activity is null) return NotFound();
            var resource = ActivityResourceFromEntityAssembler.ToResourceFromEntity(activity);
            return Ok(resource);
        }


        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates Activity",
            Description = "Creates a activity with a given data",
            OperationId = "CreateActivity"
        )]
        [SwaggerResponse(201, "The activity was created")]
        public async Task<IActionResult> CreateActivity([FromBody] CreateActivityResource createActivityResource)
        {
            var createActivtyCommand = CreateActivityCommandFromResourceAssembler.ToCommandFromResource(createActivityResource);
            var activity = await activityCommandServices.Handle(createActivtyCommand);
            if (activity is null) return BadRequest();


            // Obtener la entidad Community correspondiente al id proporcionado
            var category = await categoryQueryService.Handle(new GetCategoryById(activity.CategoryId));
            if (category is null) return BadRequest("No se pudo encontrar la categoria correspondiente.");


            // Asociar las entidades Community y Taller con la nueva promoción
            activity.Category = category;



            // Convertir la nueva promoción a un recurso para la respuesta
            var resource = ActivityResourceFromEntityAssembler.ToResourceFromEntity(activity);
            // Devolver la respuesta con el recurso de la promoción creada

            return CreatedAtAction(nameof(GetActivityById), new { AcitivityId = resource.ActivityId }, resource);

        }
    }
}
