namespace Wolds.Hr.Api.Cr.Library.Exceptions;

internal sealed class ImportEmployeeHistoryNotCreated : Exception
{
    public ImportEmployeeHistoryNotCreated() : base(ConstantMessages.ImportEmployeeNotCreated) { }
}