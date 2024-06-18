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
    public class TouristController(ITouristCommandService touristCommandService, ITouristQueryService touristQueryService, IUserQueryService profileQueryService, ExternalFeedbackService externalFeedbackService, ExternalPaymentService externalPaymentService) : ControllerBase 
    {
        [HttpPost]
        [SwaggerOperation(
        Summary = "Creates Tourist",
           Description = "Creates a Tourist with a given data",
           OperationId = "CreateTourist"
       )]
        [SwaggerResponse(201, "The tourist was created")]
        [SwaggerResponse(400, "Invalid data provided for creating the tourist")]
        [SwaggerResponse(500, "An error occurred while creating the tourist")]
        public async Task<IActionResult> CreateTourist([FromBody] CreateTouristResource createTouristResource)
        {
            var createTouristCommand = CreateTouristCommandFromResourceAssembler.ToCommandFromResource(createTouristResource);
            var tourist = await touristCommandService.Handle(createTouristCommand);
            if (tourist is null) return BadRequest();

            var user = await profileQueryService.Handle(new GetUserByIdQuery(tourist.UserId));
            if (user is null) return BadRequest();

            var review = await externalFeedbackService.FetchReviewById(tourist.ReviewId);
            if (review is null) return BadRequest();

            var booking = await externalPaymentService.FetchBookingById(tourist.BookingId);
            if (booking is null) return BadRequest();


            tourist.User = user;
            tourist.Review = review;
            tourist.Booking = booking;

            var resource = TouristResourceFromEntityAssembler.ToResourceFromEntity(tourist);
            return CreatedAtAction(nameof(GetTouristByUserId), new { touristId = tourist.TouristId }, resource);
        }

        [HttpGet("{TouristId:int}")]
        [SwaggerOperation(
            Summary = "Gets a tourist by a user id",
            Description = "Gets a user tourist for a given identifier",
            OperationId = "GetTouristByUserId"
        )]
        [SwaggerResponse(200, "The tourist was found")]
        [SwaggerResponse(404, "The tourist was not found")]
        [SwaggerResponse(500, "An error occurred while processing the request")]
        public async Task<IActionResult> GetTouristByUserId([FromRoute] int TouristId)
        {
            var tourist = await touristQueryService.Handle(new GetTouristByIdQuery(TouristId));
            if (tourist is null) return NotFound();
            var resource = TouristResourceFromEntityAssembler.ToResourceFromEntity(tourist);
            return Ok(resource);
        }
    }
}
