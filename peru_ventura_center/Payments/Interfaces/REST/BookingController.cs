using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.Payments.Domain.Model.Queries;
using peru_ventura_center.Payments.Domain.Services;
using peru_ventura_center.Payments.Interfaces.REST.Transformers;
using peru_ventura_center.Payments.Interfaces.REST.Resources;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using peru_ventura_center.profiles.Application.Internal.OutboundServices.ACL;

namespace peru_ventura_center.Payments.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class BookingController(IBookingQueryServices bookingQueryServices, IBookingCommandServices bookingCommandServices, ExternalFeedbackService externalFeedbackService) : ControllerBase
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
            var bookings = await bookingQueryServices.Handle(new GetAllBookingsQuery());
            var resource = bookings.Select(BookingResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resource);
        }

        [HttpGet("{BookingId:int}")]
        [SwaggerOperation(
            Summary = "Gets a booking by id",
            Description = "Gets a booking for a given identifier",
            OperationId = "GetBookingById"
        )]
        [SwaggerResponse(200, "The Booking was found")]
        [SwaggerResponse(404, "The Booking was not found")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<IActionResult> GetBookingById([FromRoute] int BookingId)
        {
            var booking = await bookingQueryServices.Handle(new GetBookingByIdQuery(BookingId));
            if (booking == null)    return NotFound();
            var resource = BookingResourceFromEntityAssembler.ToResourceFromEntity(booking);
            return Ok(resource);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create Booking",
            Description = "Create a Booking with a given data",
            OperationId = "CreateBooking"
        )]
        [SwaggerResponse(201, "The Booking was created")]
        [SwaggerResponse(400, "The Booking was not created")]
        [SwaggerResponse(500, "Internal Server Error")]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingResource createBookingResource)
        {
            var createBookingCommand = CreateBookingCommandFromResourceAssembler.ToCommandFromResource(createBookingResource);
            var booking = await bookingCommandServices.Handle(createBookingCommand);
            if (booking is null) return BadRequest();

            var activity = await externalFeedbackService.FetchActivityById(booking.ActivityId);
            if (activity is null) return BadRequest("No se pudo encontrar la actividad correspondiente.");
            
            booking.Activity = activity;

            var resource = BookingResourceFromEntityAssembler.ToResourceFromEntity(booking);
            return CreatedAtAction(nameof(GetBookingById), new { BookingId = resource.BookingId }, resource);
        }
    }
}