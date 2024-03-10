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

    public UserProfileController(ILogger<UserProfileController> logger, IUserProfileService userProfileService)
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

        try
        {
            return Ok(_profileService.GetRecordByUuid(userUuid, userEmail));
        }
        catch (Exception ex)
        {
            var errorMessage = $"An error occurred: {ex.Message}";
            _logger.LogError(errorMessage);
            return BadRequest(errorMessage);
        }
    }

    [HttpPost("saveprofile", Name = "saveprofile")]
    public IActionResult SaveProfile(UserProfileDto userProfile)
    {
        try
        {
            _profileService.AddNewProfile(userProfile);
            return Ok();
        }
        catch (Exception ex)
        {
            var errorMessage = $"An error occurred: {ex.Message}";
            _logger.LogError(errorMessage);
            return BadRequest(errorMessage);
        }
    }

    [HttpPost("updateproficiency", Name = "updateproficiency")]
    public IActionResult UpdateProficiency([FromBody] ProficiencyUpdateDto model)
    {
        try
        {
            _profileService.UpdateProficiency(model.ProficiencyLevelId, model.Email);
            return Ok();
        }
        catch (Exception ex)
        {
            var errorMessage = $"An error occurred: {ex.Message}";
            _logger.LogError(errorMessage);
            return BadRequest(errorMessage);
        }
    }

    [HttpPost("saveuserstatistics", Name = "saveuserstatistics"), Authorize]
    public IActionResult SaveUserStatistics(UserQuizStatisticsDto userQuizStatistics)
    {
        var userUuid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (userUuid == null) return BadRequest();

        try
        {
            _profileService.SaveUserStatistics(userQuizStatistics, userUuid);
            return Ok();
        }
        catch (Exception ex)
        {
            var errorMessage = $"An error occurred: {ex.Message}";
            _logger.LogError(errorMessage);
            return BadRequest(errorMessage);
        }
    }

    [HttpGet("userstatistics", Name = "userstatistics"), Authorize]
    public IActionResult UserStatistics()
    {
        var userUuid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        if (userUuid == null) return BadRequest();

        try
        {
            return Ok(_profileService.GetUserStatistics(userUuid));
        }
        catch (Exception ex)
        {
            var errorMessage = $"An error occurred: {ex.Message}";
            _logger.LogError(errorMessage);
            return BadRequest(errorMessage);
        }
    }
}