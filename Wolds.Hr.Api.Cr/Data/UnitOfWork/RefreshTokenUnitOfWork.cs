using Wolds.Hr.Api.Cr.Data.Context;
using Wolds.Hr.Api.Cr.Data.Interfaces;
using Wolds.Hr.Api.Cr.Data.UnitOfWork.Interfaces;

namespace Wolds.Hr.Api.Cr.Data.UnitOfWork;

internal sealed class RefreshTokenUnitOfWork(IRefreshTokenRepository refreshToken,
                                    WoldsHrDbContext dbContext) : IRefreshTokenUnitOfWork
{
    public IRefreshTokenRepository RefreshToken { get; } = refreshToken;

    private readonly WoldsHrDbContext _dbContext = dbContext;
    public Task SaveChangesAsync() => _dbContext.SaveChangesAsync();
}