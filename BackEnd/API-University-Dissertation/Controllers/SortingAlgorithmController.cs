using Microsoft.AspNetCore.Mvc;

namespace API_University_Dissertation.Controllers;

[ApiController]
[Route("sortingAlgorithm")]
public class SortingAlgorithmController : ControllerBase
{
    private readonly ILogger<SortingAlgorithmController> _logger;

    public SortingAlgorithmController(ILogger<SortingAlgorithmController> logger)
    {
        _logger = logger;
    }

    [HttpGet("bubblesort", Name = "bubbleSort")]
    public IActionResult BubbleSort()
    {
        try
        {
            int[] bubbleSort = { 4, 2, 1, 3 };
            //BubbleSortArray(bubbleSort);
            return Ok(bubbleSort);
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
}