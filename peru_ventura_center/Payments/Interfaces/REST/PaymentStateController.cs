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
    public class PaymentStateController(IPaymentStateQueryServices paymentStateQueryServices) : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
           Summary = "Gets all PaymentState",
        Description = "Gets all PaymentState",
        OperationId = "GetAllPaymentState"
        )]
        [SwaggerResponse(200, "PaymentState found")]
        public async Task<IActionResult> GetAllPaymentState()
        {
            var paymentState= await paymentStateQueryServices.Handle(new GetAllPaymentStateQuery());//TODO: Implement GetAllActivitiesQuery
            var resource = paymentState.Select(PaymentStateResourceFromEntityAssembler.ToResourceFromEntity);//
            return Ok(resource);
        }

        [HttpGet("{PaymentStateId:int}")]
        [SwaggerOperation(
            Summary = "Gets a paymentState by id",
            Description = "Gets a paymentState for a given identifier",
            OperationId = "GetPaymentStateById"
        )]
        [SwaggerResponse(200, "The paymentState was found")]
        public async Task<IActionResult> GetPaymentStateByIdQuery([FromRoute] int PaymentStateId)
        {
            var paymentState = await paymentStateQueryServices.Handle(new GetPaymentStateByIdQuery(PaymentStateId));
            if (paymentState is null) return NotFound();
            var resource = PaymentStateResourceFromEntityAssembler.ToResourceFromEntity(paymentState);
            return Ok(resource);
        }
    }
}
