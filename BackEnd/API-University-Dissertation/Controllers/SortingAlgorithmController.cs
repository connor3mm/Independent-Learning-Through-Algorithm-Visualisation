using API_University_Dissertation.Enums;
using API_University_Dissertation.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_University_Dissertation.Controllers;

[ApiController]
[Route("sortingAlgorithm")]
public class SortingAlgorithmController : ControllerBase
{
    private readonly ILogger<SortingAlgorithmController> _logger;
    private readonly ISortingAlgorithmService _sortingService;

    public SortingAlgorithmController(ILogger<SortingAlgorithmController> logger,
        ISortingAlgorithmService sortingService)
    {
        _logger = logger;
        _sortingService = sortingService;
    }

    [HttpPost("bubblesort", Name = "bubbleSort")]
    public IActionResult BubbleSort(int[] arr)
    {
        try
        {
            return Ok(_sortingService.SortingAlgorithm(SortingStrategy.BubbleSort, arr));
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    [HttpPost("selectionsort", Name = "selectionsort")]
    public IActionResult SelectionSort(int[] arr)
    {
        try
        {
            arr = new[] { 9, 5, 2, 7, 1 };
            return Ok(_sortingService.SortingAlgorithm(SortingStrategy.SelectionSort, arr));
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
}