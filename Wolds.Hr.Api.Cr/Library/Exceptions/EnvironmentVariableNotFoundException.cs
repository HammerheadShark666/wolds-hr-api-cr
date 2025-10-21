namespace Wolds.Hr.Api.Cr.Library.Exceptions;

internal sealed class EnvironmentVariableNotFoundException : Exception
{
    public EnvironmentVariableNotFoundException(string name) : base(string.Format(ConstantMessages.EnvironmentVariableNotFound, name)) { }
}