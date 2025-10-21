﻿using Wolds.Hr.Api.Cr.Data.Context;
using Wolds.Hr.Api.Cr.Data.Interfaces;
using Wolds.Hr.Api.Cr.Data.UnitOfWork.Interfaces;

namespace Wolds.Hr.Api.Cr.Data.UnitOfWork;

internal sealed class ImportEmployeeHistoryUnitOfWork(IImportEmployeeHistoryRepository history,
                                             IImportEmployeeSuccessHistoryRepository successHistory,
                                             IImportEmployeeExistingHistoryRepository existingHistory,
                                             IImportEmployeeFailedHistoryRepository failedHistory,
                                             WoldsHrDbContext dbContext) : IImportEmployeeHistoryUnitOfWork
{
    public IImportEmployeeHistoryRepository History { get; } = history;
    public IImportEmployeeSuccessHistoryRepository SuccessHistory { get; } = successHistory;
    public IImportEmployeeExistingHistoryRepository ExistingHistory { get; } = existingHistory;
    public IImportEmployeeFailedHistoryRepository FailedHistory { get; } = failedHistory;

    private readonly WoldsHrDbContext _dbContext = dbContext;

    public Task SaveChangesAsync() => _dbContext.SaveChangesAsync();
}