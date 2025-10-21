namespace Wolds.Hr.Api.Cr.Library;

internal static class EmployeeLimitHelper
{
    public static bool WillExceedLimit(int currentCount, int importCount, int maxEmployees) =>
        currentCount + importCount > maxEmployees;
}