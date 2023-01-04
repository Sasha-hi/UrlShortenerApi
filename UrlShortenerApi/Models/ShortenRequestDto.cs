using System.ComponentModel.DataAnnotations;

namespace UrlShortenerApi.Models;

public class ShortenRequestDto
{
    [Url]
    public string LongUrl { get; set; }
}