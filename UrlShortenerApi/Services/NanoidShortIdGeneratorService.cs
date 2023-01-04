using UrlShortenerApi.Services.Interfaces;

namespace UrlShortenerApi.Services;

public class NanoidShortIdGeneratorService : IShortIdGeneratorService
{
    private const string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const int Size = 10;

    public async Task<string> GenerateAsync()
    {
        return await Nanoid.Nanoid.GenerateAsync(Alphabet, Size);
    }
}