using Wolds.Hr.Api.Cr.Library.Dto.Responses;

namespace Wolds.Hr.Api.Cr.Service.Interfaces;

internal interface IImportEmployeeService
{
    Task<ImportEmployeeHistorySummaryResponse> ImportFromFileAsync(IFormFile file);
    Task<bool> MaximumNumberOfEmployeesReachedAsync(List<String> fileLines);
}