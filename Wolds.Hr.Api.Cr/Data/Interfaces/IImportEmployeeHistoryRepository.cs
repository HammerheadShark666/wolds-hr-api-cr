using Wolds.Hr.Api.Cr.Domain;

namespace Wolds.Hr.Api.Cr.Data.Interfaces;

public interface IImportEmployeeHistoryRepository
{
    Task<List<ImportEmployeeHistory>> GetAsync();
    void Add(ImportEmployeeHistory importEmployeeHistory);
    Task DeleteAsync(Guid id);
}