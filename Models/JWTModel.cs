using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LoginPanel.Models
{
    public static class JWTModel
    {
        public const string ISSUER = "LoginPanel";
        public const string AUDIENCE = "User";
        const string KEY = "_ASP.NET__LoginPanel!0721_";
        public static string? VALUE { get; set; }
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
