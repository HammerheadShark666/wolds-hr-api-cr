using Wolds.Hr.Api.Cr.Data.Interfaces;

namespace Wolds.Hr.Api.Cr.Data.UnitOfWork.Interfaces;

internal interface IDepartmentUnitOfWork
{
    IDepartmentRepository Department { get; }
    Task SaveChangesAsync();
}
