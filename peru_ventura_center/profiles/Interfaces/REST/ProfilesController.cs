using peru_ventura_center.profiles.Interfaces.REST.Transformers;
using Microsoft.AspNetCore.Mvc;
using peru_ventura_center.profiles.Domain.Model.Queries;
using peru_ventura_center.profiles.Domain.Services;
using peru_ventura_center.profiles.Interfaces.REST.Resources;
using System.Net.Mime;

namespace LearningCenterPlatform.Profiles.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class ProfilesController(IProfileCommandService profileCommandService,IProfileQueryService profileQueryService):ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProfile(CreateProfileResource resource)
        {
            var profile = await profileCommandService.Handle(CreateProfileCommandFromResourceAssembler.ToCommandFromResource(resource));
            if(profile is null) { return BadRequest(); }
            var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
            return CreatedAtAction(nameof(GetProfileById), new {profileId = profileResource.UsuarioId}, profileResource);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfiles()
        {
            var profiles = await profileQueryService.Handle(new GetAllProfilesQuery());
            var profileResource = profiles.Select(ProfileResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(profileResource);
        }

        [HttpGet("{profileId:int}")]
        public async Task<IActionResult> GetProfileById(int profileId)
        {
            var profile = await profileQueryService.Handle(new GetProfileByIdQuery(profileId));
            if(profile is null) { return NotFound(); }
            var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
            return Ok(profileResource);
        }
    }
}
