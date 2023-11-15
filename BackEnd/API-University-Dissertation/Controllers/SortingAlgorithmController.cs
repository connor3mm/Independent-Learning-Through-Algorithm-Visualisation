using API_University_Dissertation.Enums;
using API_University_Dissertation.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_University_Dissertation.Controllers;

[ApiController]
[Route("sortingAlgorithm")]
public class SortingAlgorithmController : ControllerBase
{
    private readonly ILogger<SortingAlgorithmController> _logger;
    private readonly SortingAlgorithmService _sortingService;

    public SortingAlgorithmController(ILogger<SortingAlgorithmController> logger,
        SortingAlgorithmService sortingService)
    {
        _logger = logger;
        _sortingService = sortingService;
    }

    [HttpGet("bubblesort", Name = "bubbleSort")]
    public IActionResult BubbleSort()
    {
        try
        {
            return Ok(_sortingService.SortingAlgorithm(SortingStrategy.BubbleSort));
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    [HttpGet("selectionsort", Name = "selectionsort")]
    public IActionResult SelectionSort()
    {
        try
        {
            return Ok(_sortingService.SortingAlgorithm(SortingStrategy.SelectionSort));
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
}