using Microsoft.AspNetCore.Identity;

namespace UrlShortenerMVC.Models
{
    public class ShortenedUrlModel
    {
        public int Id { get; set; }
        public string LongUrl { get; set; } = String.Empty;
        public string ShortUrl { get; set; } = String.Empty;
        public int ClickCount { get; set; }

        public int TokenId { get; set; }
        public required TokenModel Token { get; set; }

        public string? UserId { get; set; } = null;

    }
}
