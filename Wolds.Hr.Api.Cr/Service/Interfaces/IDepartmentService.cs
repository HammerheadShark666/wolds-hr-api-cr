using Wolds.Hr.Api.Cr.Library.Dto.Requests.Department;
using Wolds.Hr.Api.Cr.Library.Dto.Responses;

namespace Wolds.Hr.Api.Cr.Service.Interfaces;

internal interface IDepartmentService
{
    Task<List<DepartmentResponse>> GetAsync();
    Task<DepartmentResponse?> GetAsync(Guid id);
    Task<DepartmentResponse?> GetAsync(string name);
    Task<(bool isValid, DepartmentResponse? Department, List<string>? Errors)> AddAsync(AddDepartmentRequest addDepartmentRequest);
    Task<(bool isValid, DepartmentResponse? Department, List<string>? Errors)> UpdateAsync(UpdateDepartmentRequest updateDepartmentRequest);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}