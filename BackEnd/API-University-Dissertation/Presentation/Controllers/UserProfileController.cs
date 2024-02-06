using System.Security.Claims;
using API_University_Dissertation.Application.DTO;
using API_University_Dissertation.Core.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_University_Dissertation.Presentation.Controllers;

[ApiController]
[Route("profile")]
public class UserProfileController : ControllerBase
{
    private readonly ILogger<UserProfileController> _logger;
    private readonly IUserProfileService _profileService;

    public UserProfileController(ILogger<UserProfileController> logger, IUserProfileService userProfileService
    )
    {
        _logger = logger;
        _profileService = userProfileService;
    }

    [HttpGet, Authorize]
    public IActionResult Profile()
    {
        var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        var userUuid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (userUuid == null || userEmail == null) return BadRequest();
        return Ok(_profileService.GetRecordByUuid(userUuid, userEmail));
    }

    [HttpPost("saveprofile", Name = "saveprofile")]
    public IActionResult SaveProfile(UserProfileDto userProfile)
    {
        _profileService.AddNewProfile(userProfile);
        return Ok();
    }

    [HttpPatch("updateproficiency", Name = "updateproficiency"), Authorize]
    public IActionResult UpdateProficiency(string proficiencyLevel)
    {
        var userUuid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (userUuid == null) return BadRequest();
        _profileService.UpdateProficiency(proficiencyLevel, userUuid);
        return Ok();
    }
}