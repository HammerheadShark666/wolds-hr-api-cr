namespace Wolds.Hr.Api.Cr.Library.Exceptions;

internal sealed class AccountNotFoundException : Exception
{
    public AccountNotFoundException() : base(ConstantMessages.AccountNotFound) { }
}