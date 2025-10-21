using Wolds.Hr.Api.Cr.Domain;
using Wolds.Hr.Api.Cr.Library.Dto.Responses;

namespace Wolds.Hr.Api.Cr.Data.Interfaces;

public interface IImportEmployeeHistoryRepository
{
    Task<List<ImportEmployeeHistory>> GetAsync();
    void Add(ImportEmployeeHistory importEmployeeHistory);
    Task DeleteAsync(Guid id);
    Task<List<ImportEmployeeHistoryLatestResponse>> GetLatestAsync(int numberToGet);
}