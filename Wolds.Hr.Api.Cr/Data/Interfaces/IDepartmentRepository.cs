﻿using Wolds.Hr.Api.Cr.Domain;

namespace Wolds.Hr.Api.Cr.Data.Interfaces;

public interface IDepartmentRepository
{
    Task<List<Department>> GetAsync();
    Task<Department?> GetAsync(Guid? id);
    Task<Department?> GetAsync(string name);
    Task<bool> ExistsAsync(Guid id);
    Task<bool> ExistsAsync(string name);
    void Add(Department department);
    Task UpdateAsync(Department department);
    Task DeleteAsync(Guid id);
}