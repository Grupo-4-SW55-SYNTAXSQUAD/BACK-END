using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.Feedback.Domain.Model.Queries;
using peru_ventura_center.Feedback.Domain.Services;
using peru_ventura_center.Feedback.Interfaces.REST.Transformers;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace peru_ventura_center.Feedback.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class CategoryController(ICategoryQueryService categoryQueryService):ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(
           Summary = "Gets all Categories",
        Description = "Gets all Categories",
        OperationId = "GetAllCategories"
       )]
        [SwaggerResponse(200, "Categories found")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await categoryQueryService.Handle(new GetAllCategoriesQuery());//TODO: Implement GetAllActivitiesQuery
            var resource = categories.Select(CategoryResourceFromEntityAssembler.ToResourceFromEntity);//
            return Ok(resource);
        }

        [HttpGet("{CategoryId:int}")]
        [SwaggerOperation(
            Summary = "Gets a category by id",
            Description = "Gets a category for a given identifier",
            OperationId = "GetCategoryById"
        )]
        [SwaggerResponse(200, "The category was found")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int CategoryId)
        {
            var category = await categoryQueryService.Handle(new GetCategoryByIdQuery(CategoryId));
            if (category is null) return NotFound();
            var resource = CategoryResourceFromEntityAssembler.ToResourceFromEntity(category);
            return Ok(resource);
        }
    }
}
