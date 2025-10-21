using Wolds.Hr.Api.Cr.Data.Interfaces;

namespace Wolds.Hr.Api.Cr.Data.UnitOfWork.Interfaces;

internal interface IRefreshTokenUnitOfWork
{
    IRefreshTokenRepository RefreshToken { get; }
    Task SaveChangesAsync();
}
