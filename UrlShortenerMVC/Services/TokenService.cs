using UrlShortenerMVC.Utilities;
using UrlShortenerMVC.Data;

namespace UrlShortenerMVC.Services
{
    public class TokenService
    {
        private readonly Token _token;
        private readonly IAppDbRepository _repo;
        public TokenService(Token token, IAppDbRepository repo)
        {
            _token = token;
            _repo = repo;
        }

        public async Task Add(int quantity)
        {
            string? lastToken = await _repo.GetLastTokenAsync();
            int startIndex = _token.TokenToIndex(lastToken);
            _token.Generate(quantity, startIndex, lastToken?.Length);
        }
    }
}
