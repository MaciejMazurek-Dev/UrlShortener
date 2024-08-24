using Microsoft.AspNetCore.Identity;

namespace UrlShortenerMVC.Models
{
    public class ShortenedUrlModel
    {
        public int Id { get; set; }
        public required string LongUrl { get; set; }
        public required string ShortUrl { get; set; }
        public int ClickCount { get; set; }

        public int TokenId { get; set; }
        public required TokenModel Token { get; set; }

        public string? UserId { get; set; } = null;

    }
}
