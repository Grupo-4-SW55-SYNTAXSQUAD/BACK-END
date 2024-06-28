using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.Feedback.Domain.Model.Queries;
using peru_ventura_center.Feedback.Domain.Services;
using peru_ventura_center.Feedback.Interfaces.REST.Resources;
using peru_ventura_center.Feedback.Interfaces.REST.Transformers;
using peru_ventura_center.publishing.Application.Internal.CommandServices;
using peru_ventura_center.publishing.Domain.Services;
using peru_ventura_center.publishing.Interfaces.REST.Transformers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Linq;

namespace peru_ventura_center.Feedback.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityQueryServices _activityQueryServices;
        private readonly IActivityCommandServices _activityCommandServices;
        private readonly ICategoryQueryService _categoryQueryService;

        public ActivityController(IActivityQueryServices activityQueryServices, IActivityCommandServices activityCommandServices, ICategoryQueryService categoryQueryService)
        {
            _activityQueryServices = activityQueryServices;
            _activityCommandServices = activityCommandServices;
            _categoryQueryService = categoryQueryService;
        }

        [HttpGet]
        [SwaggerOperation(
            Summary = "Gets all Activities",
            Description = "Gets all Activities",
            OperationId = "GetAllActivities"
        )]
        [SwaggerResponse(200, "Activities found")]
        public async Task<IActionResult> GetAllActivities()
        {
            var activities = await _activityQueryServices.Handle(new GetAllActivitiesQuery()); // TODO: Implement GetAllActivitiesQuery
            var resource = activities.Select(ActivityResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resource);
        }

        [HttpGet("{ActivityId:int}")]
        [SwaggerOperation(
            Summary = "Gets an activity by id",
            Description = "Gets an activity for a given identifier",
            OperationId = "GetActivityById"
        )]
        [SwaggerResponse(200, "The activity was found")]
        public async Task<IActionResult> GetActivityById([FromRoute] int ActivityId)
        {
            var activity = await _activityQueryServices.Handle(new GetActivityByIdQuery(ActivityId));
            if (activity is null) return NotFound();
            var resource = ActivityResourceFromEntityAssembler.ToResourceFromEntity(activity);
            return Ok(resource);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates Activity",
            Description = "Creates an activity with a given data",
            OperationId = "CreateActivity"
        )]
        [SwaggerResponse(201, "The activity was created")]
        public async Task<IActionResult> CreateActivity([FromBody] CreateActivityResource createActivityResource)
        {
            var createActivityCommand = CreateActivityCommandFromResourceAssembler.ToCommandFromResource(createActivityResource);
            var activity = await _activityCommandServices.Handle(createActivityCommand);
            if (activity is null) return BadRequest();

            // Obtener la entidad Community correspondiente al id proporcionado
            var category = await _categoryQueryService.Handle(new GetCategoryByIdQuery(activity.CategoryId));
            if (category is null) return BadRequest("No se pudo encontrar la categoria correspondiente.");

            // Asociar las entidades Community y Taller con la nueva promoción
            activity.Category = category;

            // Convertir la nueva promoción a un recurso para la respuesta
            var resource = ActivityResourceFromEntityAssembler.ToResourceFromEntity(activity);
            // Devolver la respuesta con el recurso de la promoción creada
            return CreatedAtAction(nameof(GetActivityById), new { ActivityId = resource.ActivityId }, resource);
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(
           Summary = "Delete activity",
           Description = "Delete activity with a given id",
           OperationId = "DeleteActivity"
         )]
        [SwaggerResponse(201, "The activity was deleted")]
        public async Task<IActionResult> DeleteActivity([FromRoute] int id)
        {
            var deleteActivityResource = new DeleteActivityResource(id);
            var deleteActivityCommand = DeleteActivityCommandFromResourceAssembler.ToCommandFromResource(deleteActivityResource);
            var activity = await _activityCommandServices.Handle(deleteActivityCommand);
            if (activity is null) return BadRequest();

            var resource = ActivityResourceFromEntityAssembler.ToResourceFromEntity(activity);

            return CreatedAtAction(nameof(GetActivityById), new { ActivityId = resource.ActivityId }, resource);
        }

        [HttpPatch("{id:int}")]
        [SwaggerOperation(
            Summary = "Patch activity",
            Description = "Update partially activity with given data",
            OperationId = "PatchActivity"
            )]
        [SwaggerResponse(201, "The Activity was updated")]
        public async Task<IActionResult> PatchActivity([FromRoute] int id, [FromBody] PatchActivityResource patchActivityResource)
        {
            var patchActivityCommand = PatchActivityCommandFromResourceAssembler.ToCommandFromResource(patchActivityResource) with { ActivityId = id };
            var activity = await _activityCommandServices.Handle(patchActivityCommand);
            if (activity is null) return BadRequest();

            var resource = ActivityResourceFromEntityAssembler.ToResourceFromEntity(activity);

            return CreatedAtAction(nameof(GetActivityById), new { ActivityId = resource.ActivityId }, resource);
        }
    }
}
