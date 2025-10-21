using Wolds.Hr.Api.Cr.Domain;
using Wolds.Hr.Api.Cr.Library.Dto.Responses;

namespace Wolds.Hr.Api.Cr.Service.Interfaces;

internal interface IRefreshTokenService
{
    Task<JwtRefreshToken> RefreshTokenAsync(string token, string ipAddress);
    void RemoveExpiredRefreshTokens(Guid accountId);
    Task AddRefreshTokenAsync(RefreshToken refreshToken);
    Task DeleteRefreshTokenAsync(string refreshTokenString);
    RefreshToken GenerateRefreshToken(string ipAddress, Account account);
}