namespace Wolds.Hr.Api.Cr.Library.Exceptions;

internal sealed class DepartmentNotFoundException : Exception
{
    public DepartmentNotFoundException() : base(ConstantMessages.DocumentNotFound) { }

    public DepartmentNotFoundException(string message)
        : base(message)
    { }
}