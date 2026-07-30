using PayFlow.Infrastructure.Features.Auth.DTOs;

namespace PayFlow.Api.Extensions
{
    public static class CookieExtensions
    {
        private const string AccessTokenCookie = "accessToken";
        private const string RefreshTokenCookie = "refreshToken";

        public static void SetAuthCookies(this HttpResponse response, AuthUserDto auth, IWebHostEnvironment env)
        {
            var isProduction = !env.IsDevelopment();

            response.Cookies.Append(AccessTokenCookie, auth.AccessToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = auth.ExpiresAt,
                Path = "/"
            });

            response.Cookies.Append(RefreshTokenCookie, auth.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddDays(7),
                Path = "/api/auth"
            });
        }

        public static void ClearAuthCookies(this HttpResponse response)
        {
            response.Cookies.Delete(AccessTokenCookie, new CookieOptions
            {
                Path = "/",
                Secure = true,
                SameSite = SameSiteMode.None
            });

            response.Cookies.Delete(RefreshTokenCookie, new CookieOptions
            {
                Path = "/api/auth",
                Secure = true,
                SameSite = SameSiteMode.None
            });
        }

        public static string? GetRefreshToken(this HttpRequest request)
        {
            return request.Cookies[RefreshTokenCookie];
        }
    }
}