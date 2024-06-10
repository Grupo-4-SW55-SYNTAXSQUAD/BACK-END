using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.Payments.Domain.Services;
using peru_ventura_center.Payments.Interfaces.REST.Resources;
using peru_ventura_center.Payments.Domain.Model.Queries;
using peru_ventura_center.Payments.Interfaces.REST.Transformers;
using peru_ventura_center.Payments.Domain.Model.Aggregates;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;
using peru_ventura_center.Payments.Domain.Model.Commands;
using peru_ventura_center.Publishing.Domain.Services;
using peru_ventura_center.Publishing.Interfaces.REST.Transformers;


namespace peru_ventura_center.Payments.Interfaces.REST
{

    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class PaymentController(IPaymentQueryServices paymentQueryServices, IPaymentCommandServices paymentCommandServices, IPaymentTypeQueryServices paymentTypeQueryServices, IPaymentStateQueryServices paymentStateQueryServices) : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "Gets all Payments",
            Description = "Gets all Payments",
            OperationId = "GetAllPayments"
        )]
        [SwaggerResponse(200, "Payments found")]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await paymentQueryServices.Handle(new GetAllPaymentQuery());
            var resource = payments.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resource);
        }

        [HttpGet("{PaymentId:int}")]
        [SwaggerOperation(
            Summary = "Gets a payment by id",
            Description = "Gets a payment for a given identifier",
            OperationId = "GetPaymentById"
        )]
        [SwaggerResponse(200, "The payment was found")]
        public async Task<IActionResult> GetPaymentById([FromRoute] int PaymentId)
        {
            var payment = await paymentQueryServices.Handle(new GetPaymentByIdQuery(PaymentId));
            if (payment is null) return NotFound();
            var resource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
            return Ok(resource);
        }

         [HttpPost]
        [SwaggerOperation(
            Summary = "Creates Payment",
            Description = "Creates a payment with a given data",
            OperationId = "CreatePayment"
        )]
        [SwaggerResponse(201, "The payment was created")]
        public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentResource createPaymentResource)
        {
            var createPaymentCommand= CreatePaymentCommandFromResourceAssembler. ToCommandFromResource(createPaymentResource);
            var payment = await paymentCommandServices.Handle(createPaymentCommand);
            if(payment is null) return NotFound();

            var paymentType = await paymentTypeQueryServices.Handle(new GetPaymentTypeByIdQuery(payment.PaymentTypeId));
            if (paymentType is null) return BadRequest("No se pudo encontrar el typo de tarejta.");

            var paymentState = await paymentStateQueryServices.Handle(new GetPaymentStateByIdQuery(payment.PaymentStateId));
            if (paymentState is null) return BadRequest("No se pudo encontrar el estado ");
            
            payment.PaymentState = paymentState;
            payment.PaymentType = paymentType;

            var resource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
            return CreatedAtAction(nameof(GetPaymentById), new { PaymentId = resource.PaymentId }, resource);
        }

    }
}
