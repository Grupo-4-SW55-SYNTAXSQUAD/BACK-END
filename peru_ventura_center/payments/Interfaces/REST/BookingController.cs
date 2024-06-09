using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.payments.Domain.Model.Queries;
using peru_ventura_center.payments.Domain.Services;
using peru_ventura_center.payments.Interfaces.REST.Resources;
using peru_ventura_center.payments.Interfaces.REST.Transformers;
using System.Net.Mime;

namespace peru_ventura_center.payments.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class BookingController(IBookingCommandService reservationStatusCommandService, IBookingQueryService bookingQueryService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProfile(CreateBookingResource resource)
        {
            var booking = await reservationStatusCommandService.Handle(CreateBookingCommandFromResourceAssembler.ToCommandFromResource(resource));
            if (booking is null) { return BadRequest(); }

            var bookingStateResource = BookingResourceFromEntityAssembler.ToResourceFromEntity(booking);
            return CreatedAtAction(nameof(GetBookingById), new { profileId = booking.booking_id }, bookingStateResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var booking = await bookingQueryService.Handle(new GetAllBookingQuery());
            var bookingResources = booking.Select(BookingResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(bookingResources);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await bookingQueryService.Handle(new GetBookingByIdQuery(id));
            if (booking is null)
            {
                return NotFound();
            }

            var bookingResource = BookingResourceFromEntityAssembler.ToResourceFromEntity(booking);
            return Ok(bookingResource);
        }

    }
}
