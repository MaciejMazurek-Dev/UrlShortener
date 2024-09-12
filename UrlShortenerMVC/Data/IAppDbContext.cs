using Microsoft.EntityFrameworkCore;
using UrlShortenerMVC.Models;

namespace UrlShortenerMVC.Data
{
    public interface IAppDbContext
    {
        DbSet<ShortenedUrlModel> ShortenedUrl { get; set; }
        DbSet<TokenModel> TokenModel { get; set; }
    }
}