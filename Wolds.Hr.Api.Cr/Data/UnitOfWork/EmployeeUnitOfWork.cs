﻿using Wolds.Hr.Api.Cr.Data.Context;
using Wolds.Hr.Api.Cr.Data.Interfaces;
using Wolds.Hr.Api.Cr.Data.UnitOfWork.Interfaces;

namespace Wolds.Hr.Api.Cr.Data.UnitOfWork;

internal sealed class EmployeeUnitOfWork(IEmployeeRepository employeeRepository, WoldsHrDbContext dbContext) : IEmployeeUnitOfWork
{
    public IEmployeeRepository Employee { get; } = employeeRepository;

    private readonly WoldsHrDbContext _dbContext = dbContext;

    public Task SaveChangesAsync() => _dbContext.SaveChangesAsync();
}
