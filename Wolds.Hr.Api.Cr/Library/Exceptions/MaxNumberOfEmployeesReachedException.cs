namespace Wolds.Hr.Api.Cr.Library.Exceptions;

internal sealed class MaxNumberOfEmployeesReachedException : Exception
{
    public MaxNumberOfEmployeesReachedException() : base(ConstantMessages.MaxNumberOfEmployeesReached) { }

    public MaxNumberOfEmployeesReachedException(string message)
        : base(message)
    { }
}
