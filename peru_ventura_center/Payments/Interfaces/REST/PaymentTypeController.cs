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
    public class PaymentTypeController(IPaymentTypeQueryServices paymentTypeQueryServices) : ControllerBase
    {
            [HttpGet]
            [SwaggerOperation(
               Summary = "Gets all PaymentType",
            Description = "Gets all PaymentType",
            OperationId = "GetAllPaymentType"
            )]
            [SwaggerResponse(200, "PaymentType found")]
            public async Task<IActionResult> GetAllPaymentType()
            {
                var paymenType = await paymentTypeQueryServices.Handle(new GetAllPaymentTypeQuery());//TODO: Implement GetAllActivitiesQuery
                var resource = paymenType.Select(PaymentTypeResourceFromEntityAssembler.ToResourceFromEntity);//
                return Ok(resource);
            }

            [HttpGet("{PaymentTypeId:int}")]
            [SwaggerOperation(
                Summary = "Gets a paymentType by id",
                Description = "Gets a paymentType for a given identifier",
                OperationId = "GetPaymentTypeById"
            )]
            [SwaggerResponse(200, "The paymentType was found")]
            public async Task<IActionResult> GetPaymentTyByIdQuery([FromRoute] int PaymentTypeId)
            {
                var paymenType = await paymentTypeQueryServices.Handle(new GetPaymentTypeByIdQuery(PaymentTypeId));
                if (paymenType is null) return NotFound();
                var resource = PaymentTypeResourceFromEntityAssembler.ToResourceFromEntity(paymenType);
                return Ok(resource);
            }
    }
   
}
