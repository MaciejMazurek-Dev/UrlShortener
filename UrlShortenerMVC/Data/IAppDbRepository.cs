using UrlShortenerMVC.Models;

namespace UrlShortenerMVC.Data
{
    public interface IAppDbRepository
    {
        Task<bool> AddTokensAsync(IQueryable<TokenModel> tokens);
        Task<string?> GetLastTokenAsync();
    }
}