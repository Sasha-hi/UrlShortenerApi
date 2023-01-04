namespace UrlShortenerApi.Services.Interfaces;

public interface IShortUrlService
{
    Task<bool> Get(string key);
}