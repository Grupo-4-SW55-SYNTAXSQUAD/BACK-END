using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.Payments.Domain.Model.Queries;
using peru_ventura_center.Payments.Domain.Services;
using peru_ventura_center.Payments.Interfaces.REST.Resources;
using peru_ventura_center.Payments.Interfaces.REST.Transformers;
using System.Net.Mime;

namespace peru_ventura_center.Payments.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class BookingStateController(IBookingStateCommandService reservationStatusCommandService, IBookingStateQueryService bookingStateQueryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookingState = await bookingStateQueryService.Handle(new GetAllBookingStateQuery());
            var bookingStateResources = bookingState.Select(BookingStateResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(bookingStateResources);
        }

        [HttpGet("{id:int}")]
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
