namespace Wolds.Hr.Api.Cr.Library.Exceptions;

internal sealed class RefreshTokenNotFoundException : Exception
{
    public RefreshTokenNotFoundException() : base(ConstantMessages.InvalidToken) { }
}