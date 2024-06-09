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
    public class BookingStateController(IBookingCommandService reservationStatusCommandService, IBookingQueryService reservationStatusQueryService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProfile(BookingResource resource)
        {
            var bookingState = await reservationStatusCommandService.Handle(CreateBookingCommandFromResourceAssembler.ToCommandFromResource(resource));
            if (bookingState is null) { return BadRequest(); }

            var bookingStateResource = BookingResourceFromEntityAssembler.ToResourceFromEntity(bookingState);
            return CreatedAtAction(nameof(GetBookingStateById), new { profileId = bookingState.booking_state_id }, bookingStateResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservationStatus()
        {
            var bookingState = await reservationStatusQueryService.Handle(new GetAllBookingQuery());
            var bookingStateResources = bookingState.Select(BookingResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(bookingStateResources);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookingStateById(int id)
        {
            var bookingState = await reservationStatusQueryService.Handle(new GetBookingByIdQuery(id));
            if (bookingState is null)
            {
                return NotFound();
            }

            var bookingStateResource = BookingResourceFromEntityAssembler.ToResourceFromEntity(bookingState);
            return Ok(bookingStateResource);
        }

    }
}
