using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.Feedback.Domain.Model.Queries;
using peru_ventura_center.Feedback.Domain.Services;
using peru_ventura_center.Feedback.Interfaces.REST.Resources;
using peru_ventura_center.Feedback.Interfaces.REST.Transformers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace peru_ventura_center.Feedback.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ReviewController(IReviewCommandServices reviewCommandServices,
    IReviewQueryServices reviewQueryServices,IActivityQueryServices activityQueryServices):ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
            Summary = "Gets all Reviews",
            Description = "Gets all Reviews",
            OperationId = "GetAllReviews"
        )]
        [SwaggerResponse(200, "Reviews found")]
        public async Task<IActionResult> GetAllReviews()
        {
            var reviews = await reviewQueryServices.Handle(new GetAllReviewsQuery());//TODO: Implement GetAllActivitiesQuery
            var resource = reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);//
            return Ok(resource);
        }

        [HttpGet("{ReviewId:int}")]
        [SwaggerOperation(
        Summary = "Gets a review by id",
            Description = "Gets a review for a given identifier",
            OperationId = "GetReviewById"
        )]
        [SwaggerResponse(200, "The review was found")]
        public async Task<IActionResult> GetReviewById([FromRoute] int ReviewId)
        {
            var review = await reviewQueryServices.Handle(new GetReviewById(ReviewId));
            if (review is null) return NotFound();
            var resource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
            return Ok(resource);
        }


        [HttpPost]
        [SwaggerOperation(
            Summary = "Creates Review",
            Description = "Creates a review with a given data",
            OperationId = "CreateReview"
        )]
        [SwaggerResponse(201, "The review was created")]
        public async Task<IActionResult> CreateActivity([FromBody] CreateReviewResource createReviewResource)
        {
            var createReviewCommand = CreateReviewCommandFromResourceAssembler.ToCommandFromResource(createReviewResource);
            var review = await reviewCommandServices.Handle(createReviewCommand);
            if (review is null) return BadRequest();


            var activity = await activityQueryServices.Handle(new GetActivityByIdQuery(review.ActivityId));
            if (activity is null) return BadRequest("No se pudo encontrar la categoria correspondiente.");


            review.Activity = activity;



            var resource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);

            return CreatedAtAction(nameof(GetReviewById), new { ReviewId = resource.ReviewId }, resource);

        }
    }
}
