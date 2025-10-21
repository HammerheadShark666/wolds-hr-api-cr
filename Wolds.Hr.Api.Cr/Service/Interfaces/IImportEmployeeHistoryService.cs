using Wolds.Hr.Api.Cr.Library.Dto.Responses;

namespace Wolds.Hr.Api.Cr.Service.Interfaces;

internal interface IImportEmployeeHistoryService
{
    Task<EmployeePagedResponse> GetImportedEmployeesHistoryAsync(Guid id, int page, int pageSize);
    Task<ImportEmployeeExistingHistoryPagedResponse> GetImportedEmployeeExistingHistoryAsync(Guid id, int page, int pageSize);
    Task<ImportEmployeeFailedHistoryPagedResponse> GetImportedEmployeeFailedHistoryAsync(Guid id, int page, int pageSize);
    Task DeleteAsync(Guid id);
    Task<List<ImportEmployeeHistoryResponse>> GetAsync();
    Task<List<ImportEmployeeHistoryLatestResponse>> GetLatestAsync(int numberOfLatestImportsToGet);
}