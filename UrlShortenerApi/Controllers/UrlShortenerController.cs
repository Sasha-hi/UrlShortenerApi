using Microsoft.AspNetCore.Mvc;
using UrlShortenerApi.Models;
using UrlShortenerApi.Services.Interfaces;

namespace UrlShortenerApi.Controllers;

[ApiController]
[Route("api")]
public class UrlShortenerController : ControllerBase
{
    private readonly ILogger<UrlShortenerController> _logger;
    private readonly IShortIdGeneratorService _shortIdGeneratorService;

    public UrlShortenerController(ILogger<UrlShortenerController> logger, IShortIdGeneratorService shortIdGeneratorService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _shortIdGeneratorService = shortIdGeneratorService ?? throw new ArgumentNullException(nameof(shortIdGeneratorService));
    }

    [HttpGet("")]
    public string Index()
    {
        return "Service available";
    }

    [HttpGet("{key}")]
    [ProducesResponseType(StatusCodes.Status302Found)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Expand(string key)
    {
        return Redirect("https://google.com");
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ShortenResponseDto>> Shorten(ShortenRequestDto requestDto)
    {
        var shortId = await _shortIdGeneratorService.GenerateAsync();
        
        var responseDto = new ShortenResponseDto
        {
            ShortUrl = shortId
        };
        var routeValues = new { key = shortId };
        return CreatedAtAction(nameof(Expand), routeValues, responseDto);
    }
}