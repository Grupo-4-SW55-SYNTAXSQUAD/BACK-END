using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.Payments.Domain.Model.Queries;
using peru_ventura_center.Payments.Domain.Services;
using peru_ventura_center.Payments.Interfaces.REST.Transformers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace peru_ventura_center.Payments.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class BookingStateController( IBookingStateQueryService bookingStateQueryService) : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
                       Summary = "Gets all Bookings",
                       Description = "Gets all Bookings",
                       OperationId = "GetAllBookings"
                   )]
        [SwaggerResponse(200, "Bookings found")]
        [SwaggerResponse(404, "No Bookings found")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookingState = await bookingStateQueryService.Handle(new GetAllBookingStateQuery());
            var bookingStateResources = bookingState.Select(BookingStateResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(bookingStateResources);
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(
                       Summary = "Gets a booking by id",
                       Description = "Gets a booking for a given identifier",
                       OperationId = "GetBookingById"
                   )]
        [SwaggerResponse(200, "The Booking was found")]
        [SwaggerResponse(404, "The Booking was not found")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var bookingState = await bookingStateQueryService.Handle(new GetBookingStateByIdQuery(id));
            if (bookingState is null)
            {
                return NotFound();
            }

            var bookingStateResource = BookingStateResourceFromEntityAssembler.ToResourceFromEntity(bookingState);
            return Ok(bookingStateResource);
        }

    }
}
