using API_University_Dissertation.Core.Data.Enums;
using API_University_Dissertation.Core.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_University_Dissertation.Presentation.Controllers;

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
            return Ok(_sortingService.SortingAlgorithm(SortingStrategy.SelectionSort, arr));
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    [HttpPost("mergesort", Name = "mergesort")]
    public IActionResult MergeSort(int[] arr)
    {
        try
        {
            return Ok(_sortingService.SortingAlgorithm(SortingStrategy.MergeSort, arr));
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    [HttpPost("insertionsort", Name = "insertionsort")]
    public IActionResult InsertionSort(int[] arr)
    {
        try
        {
            return Ok(_sortingService.SortingAlgorithm(SortingStrategy.InsertionSort, arr));
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
    
    [HttpPost("quicksort", Name = "quicksort")]
    public IActionResult QuickSort(int[] arr)
    {
        try
        {
            return Ok(_sortingService.SortingAlgorithm(SortingStrategy.QuickSort, arr));
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
}