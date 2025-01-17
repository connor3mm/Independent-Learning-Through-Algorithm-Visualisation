using API_University_Dissertation.Application.Services.Services;
using API_University_Dissertation.Core.Data.Enums;
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
            var errorMessage = $"An error occurred: {ex.Message}";
            _logger.LogError(errorMessage);
            return BadRequest(errorMessage);
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
            var errorMessage = $"An error occurred: {ex.Message}";
            _logger.LogError(errorMessage);
            return BadRequest(errorMessage);
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
            var errorMessage = $"An error occurred: {ex.Message}";
            _logger.LogError(errorMessage);
            return BadRequest(errorMessage);
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
            var errorMessage = $"An error occurred: {ex.Message}";
            _logger.LogError(errorMessage);
            return BadRequest(errorMessage);
        }
    }

    [HttpPost("shellsort", Name = "shellsort")]
        public IActionResult ShellSort(int[] arr)
        {
            try
            {
                return Ok(_sortingService.SortingAlgorithm(SortingStrategy.ShellSort, arr));
            }
            catch (Exception ex)
            {
                var errorMessage = $"An error occurred: {ex.Message}";
                _logger.LogError(errorMessage);
                return BadRequest(errorMessage);
            }
    }
}