using System.ComponentModel.DataAnnotations;

namespace UrlShortenerMVC.Models
{
    public class TokenModel
    {
        public int Id { get; set; }
        public required string Token { get; set; }
        public TokenState State { get; set; }
    }

    public enum TokenState
    {
        Unused = 0,
        Used = 1,
        NotAllowed = 2
    }
}
