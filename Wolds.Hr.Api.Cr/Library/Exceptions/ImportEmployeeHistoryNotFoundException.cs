namespace Wolds.Hr.Api.Cr.Library.Exceptions;

internal sealed class ImportEmployeeHistoryNotFoundException : Exception
{
    public ImportEmployeeHistoryNotFoundException() : base(ConstantMessages.ImportEmployeeNotFound) { }
}
