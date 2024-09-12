using Microsoft.EntityFrameworkCore;
using UrlShortenerMVC.Models;

namespace UrlShortenerMVC.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {
        }

        public DbSet<ShortenedUrlModel> ShortenedUrl { get; set; }
        public DbSet<TokenModel> TokenModel { get; set; }



    }
}
