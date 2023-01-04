namespace UrlShortenerApi.Services.Interfaces;

public interface IShortIdGeneratorService
{
    Task<string> GenerateAsync();
}