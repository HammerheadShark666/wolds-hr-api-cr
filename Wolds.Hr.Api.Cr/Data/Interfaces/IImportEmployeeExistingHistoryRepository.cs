using Wolds.Hr.Api.Cr.Domain;

namespace Wolds.Hr.Api.Cr.Data.Interfaces;

public interface IImportEmployeeExistingHistoryRepository
{
    void Add(ImportEmployeeExistingHistory employee);
    Task<(List<ImportEmployeeExistingHistory>, int)> GetAsync(Guid id, int page, int pageSize);
}