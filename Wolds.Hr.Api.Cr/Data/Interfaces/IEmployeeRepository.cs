using Wolds.Hr.Api.Cr.Domain;

namespace Wolds.Hr.Api.Cr.Data.Interfaces;

public interface IEmployeeRepository
{
    Task<(List<Employee>, int)> GetAsync(string keyword, Guid? departmentId, int page, int pageSize);
    Task<int> CountAsync();
    Task<Employee?> GetAsync(Guid id);
    void Add(Employee employee);
    Task<Employee> UpdateAsync(Employee employee);
    Task DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
    Task<bool> ExistsAsync(string surname, string firstName, DateOnly? dateOfBirth);
}