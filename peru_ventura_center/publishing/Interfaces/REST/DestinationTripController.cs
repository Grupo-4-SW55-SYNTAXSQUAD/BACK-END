using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.Publishing.Domain.Model.Queries;
using peru_ventura_center.Publishing.Domain.Services;
using peru_ventura_center.Publishing.Interfaces.REST.Transformers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace peru_ventura_center.Publishing.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class DestinationTripController(IDestinationTripQueryServices destinationTripQueryServices):ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "Gets all destination trips",
            Description = "Gets all destination trips",
            OperationId = "GetAllDestinationTrips"
        )]
        [SwaggerResponse(200, "Destination Trips found")]
        public async Task<IActionResult> GetAllDestinationTtips()
        {
            var destinationTrip = await destinationTripQueryServices.Handle(new GetAllDestinationTripsQuery());//TODO: Implement GetAllActivitiesQuery
            var resource = destinationTrip.Select(DestinationTripResourceFromEntityAssembler.ToResourceFromEntity);//
            return Ok(resource);
        }

        [HttpGet("{DestinationTripId:int}")]
        [SwaggerOperation(
            Summary = "Gets a destination trip by id",
            Description = "Gets a destination trip for a given identifier",
            OperationId = "GetDestinationTripById"
        )]
        [SwaggerResponse(200, "The destination trip was found")]
        public async Task<IActionResult> GetDestinationTripById([FromRoute] int DestinationTripId)
        {
            var destinationTrip = await destinationTripQueryServices.Handle(new GetDestinationTripById(DestinationTripId));
            if (destinationTrip is null) return NotFound();
            var resource = DestinationTripResourceFromEntityAssembler.ToResourceFromEntity(destinationTrip);
            return Ok(resource);
        }
    }
}
