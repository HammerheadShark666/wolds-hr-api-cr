namespace Wolds.Hr.Api.Cr.Library.Helpers.Interfaces;

internal interface ICookieHelper
{
    void SetAccessTokenCookie(HttpContext http, string token);
    void SetRefreshTokenCookie(HttpContext http, string refreshToken);
}