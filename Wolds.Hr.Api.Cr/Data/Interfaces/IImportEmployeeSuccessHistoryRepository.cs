using Wolds.Hr.Api.Cr.Domain;

namespace Wolds.Hr.Api.Cr.Data.Interfaces;

public interface IImportEmployeeSuccessHistoryRepository
{
    Task<int> CountAsync(Guid id);
    Task<(List<Employee>, int)> GetAsync(Guid id, int page, int pageSize);
}