using Microsoft.EntityFrameworkCore;
using Wolds.Hr.Api.Cr.Data.Context;
using Wolds.Hr.Api.Cr.Data.Interfaces;
using Wolds.Hr.Api.Cr.Domain;
using Wolds.Hr.Api.Cr.Library.Dto.Responses;
using Wolds.Hr.Api.Cr.Library.Exceptions;

namespace Wolds.Hr.Api.Cr.Data;

internal sealed class ImportEmployeeHistoryRepository(WoldsHrDbContext woldsHrDbContext) : IImportEmployeeHistoryRepository
{
    public async Task<List<ImportEmployeeHistory>> GetAsync()
    {
        return await woldsHrDbContext.ImportEmployeesHistory
                             .OrderByDescending(a => a.Date)
                             .AsNoTracking()
                             .ToListAsync();
    }

    public void Add(ImportEmployeeHistory importEmployeeHistory)
    {
        woldsHrDbContext.ImportEmployeesHistory.Add(importEmployeeHistory);
    }

    public async Task DeleteAsync(Guid id)
    {
        var employeeImport = await woldsHrDbContext.ImportEmployeesHistory.FirstOrDefaultAsync(e => e.Id.Equals(id));
        if (employeeImport != null)
        {
            var import = await woldsHrDbContext.ImportEmployeesHistory
                            .Include(i => i.ImportedEmployees)
                            .Include(i => i.ExistingEmployees)
                            .FirstOrDefaultAsync(i => i.Id.Equals(id));

            if (import != null)
            {
                woldsHrDbContext.Employees.RemoveRange(import.ImportedEmployees);
                woldsHrDbContext.ImportEmployeesExistingHistory.RemoveRange(import.ExistingEmployees);
                woldsHrDbContext.ImportEmployeesHistory.Remove(import);
            }
        }
        else
            throw new ImportEmployeeHistoryNotFoundException();
    }



    public async Task<List<ImportEmployeeHistoryLatestResponse>> GetLatestAsync(int numberToGet)
    {
        return await (from importEmployeesHistory in woldsHrDbContext.ImportEmployeesHistory
                      orderby importEmployeesHistory.Date descending
                      select new ImportEmployeeHistoryLatestResponse
                      {
                          Id = importEmployeesHistory.Id,
                          Date = importEmployeesHistory.Date,
                          ImportedEmployeesCount = importEmployeesHistory.ImportedEmployees.Count(),
                          ImportedEmployeesErrorsCount = importEmployeesHistory.FailedEmployees.Count(),
                          ImportedEmployeesExistingCount = importEmployeesHistory.ExistingEmployees.Count()
                      }).Take(5).ToListAsync();
    }
}