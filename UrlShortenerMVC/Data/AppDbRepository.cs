using Microsoft.EntityFrameworkCore;
using UrlShortenerMVC.Models;
using UrlShortenerMVC.Services;

namespace UrlShortenerMVC.Data
{
    public class AppDbRepository : IAppDbRepository
    {
        private readonly AppDbContext _db;
        private readonly ILogger<AppDbRepository> _logger;
        public AppDbRepository(AppDbContext db, ILogger<AppDbRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<bool> AddTokensAsync(IQueryable<TokenModel> tokens)
        {
            await _db.Tokens.AddRangeAsync(tokens);
            int result = await _db.SaveChangesAsync();
            _logger.LogInformation($"Added {result} tokens into database.");

            if (result > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<string?> GetLastTokenAsync()
        {
            var result = await _db.Tokens
                .OrderByDescending(i => i.Id)
                .FirstOrDefaultAsync();
            return result?.Token;
        }
    }
}
