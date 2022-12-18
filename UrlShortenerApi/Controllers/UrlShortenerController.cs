using Microsoft.AspNetCore.Mvc;

namespace UrlShortenerApi.Controllers;

[ApiController]
[Route("api")]
public class UrlShortenerController : ControllerBase
{
    [HttpGet("")]
    public string Index()
    {
        return "Service available";
    }

    [HttpGet("{key}")]
    [ProducesResponseType(StatusCodes.Status302Found)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Expand(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            return BadRequest($"Argument {nameof(key)} is null or empty or whitespace");

        return Redirect("https://google.com");
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<string> Shorten(string sourceUrl)
    {
        if (string.IsNullOrWhiteSpace(sourceUrl))
            return BadRequest($"Argument {nameof(sourceUrl)} is null or empty or whitespace");

        var routeValues = new { key = "key" };
        return CreatedAtAction(nameof(Expand), routeValues, "result url");
    }
}