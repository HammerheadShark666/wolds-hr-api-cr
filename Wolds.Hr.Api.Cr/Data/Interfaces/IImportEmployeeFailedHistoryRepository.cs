using Wolds.Hr.Api.Cr.Domain;

namespace Wolds.Hr.Api.Cr.Data.Interfaces;

public interface IImportEmployeeFailedHistoryRepository
{
    void Add(ImportEmployeeFailedHistory importEmployeeFailedHistory);
    Task<(List<ImportEmployeeFailedHistory>, int)> GetAsync(Guid id, int page, int pageSize);
}
