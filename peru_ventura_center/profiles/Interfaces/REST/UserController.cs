using peru_ventura_center.profiles.Interfaces.REST.Transformers;
using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.profiles.Domain.Model.Queries;
using peru_ventura_center.profiles.Domain.Services;
using peru_ventura_center.profiles.Interfaces.REST.Resources;
using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;
using LearningCenterPlatform.Profiles.Application.Internal.CommandServices;
using peru_ventura_center.Profiles.Interfaces.REST.Resources;
using peru_ventura_center.Profiles.Interfaces.REST.Transformers;

namespace LearningCenterPlatform.Profiles.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class UserController(IUserCommandService profileCommandService,IUserQueryService profileQueryService):ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(
           Summary = "Creates User",
           Description = "Creates a User with the provided data",
           OperationId = "CreateUser"
       )]
        [SwaggerResponse(201, "The request was created")]
        [SwaggerResponse(400, "Invalid data provided for creating the user")]
        [SwaggerResponse(500, "An error occurred while creating the user")]
        public async Task<IActionResult> CreateUser(CreateUserResource resource)
        {
            try
            {
                var profile = await profileCommandService.Handle(CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource));
                if (profile is null) { return BadRequest(new { Error = "Unable to create the user." }); }
                var profileResource = UserResourceFromEntityAssembler.ToResourceFromEntity(profile);
                return CreatedAtAction(nameof(CreateUser), new { profileId = profileResource.UserId }, profileResource);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }

        }

        [HttpGet]
        [SwaggerOperation(
                       Summary = "Gets all Users",
                       Description = "Gets all Users",
                       OperationId = "GetAllUsers"
                   )]
        [SwaggerResponse(200, "Users found")]
        [SwaggerResponse(404, "No users found")]
        [SwaggerResponse(500, "An error occurred while processing the request")]
        public async Task<IActionResult> GetAllProfiles()
        {
            var profiles = await profileQueryService.Handle(new GetAllProfilesQuery());
            var profileResource = profiles.Select(UserResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(profileResource);
        }

        [HttpGet("{UserId:int}")]
        [SwaggerOperation(
            Summary = "Gets a User by id",
            Description = "Gets a user for a given identifier",
            OperationId = "GetUserById"
        )]
        [SwaggerResponse(200, "The user was found")]
        [SwaggerResponse(404, "The user was not found")]
        [SwaggerResponse(500, "An error occurred while processing the request")]
        public async Task<IActionResult> GetUserById(int UserId)
        {
            var profile = await profileQueryService.Handle(new GetUserByIdQuery(UserId));
            if(profile is null) { return NotFound(); }
            var profileResource = UserResourceFromEntityAssembler.ToResourceFromEntity(profile);
            return Ok(profileResource);
        }
        [HttpDelete("{UserId:int}")]
        [SwaggerOperation(
            Summary = "Deletes a User by id",
            Description = "Deletes a user for a given identifier",
            OperationId = "DeleteUser"
        )]
        [SwaggerResponse(204, "User deleted")]
        [SwaggerResponse(404, "The user was not found")]
        [SwaggerResponse(500, "An error occurred while processing the request")]
        public async Task<IActionResult> DeleteUser(int UserId)
        {
            try
            {
                await profileCommandService.DeleteUser(UserId);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
        [HttpPatch("{userId:int}")]
        [SwaggerOperation(
           Summary = "Update User attributes",
           Description = "Partially updates attributes of a User identified by userId",
           OperationId = "PatchUser"
       )]
        [SwaggerResponse(204, "User updated successfully")]
        [SwaggerResponse(400, "Invalid data provided for updating the user")]
        [SwaggerResponse(404, "The user was not found")]
        [SwaggerResponse(500, "An error occurred while processing the request")]
        public async Task<IActionResult> PatchUser(int userId, PatchUserResource resource)
        {
            try
            {
                await profileCommandService.PatchUser(userId, user =>
                {
                    PatchUserCommandFromResourceAssembler.ApplyPatch(user, resource);
                });

                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { Error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = ex.Message });
            }
        }
    }
}
