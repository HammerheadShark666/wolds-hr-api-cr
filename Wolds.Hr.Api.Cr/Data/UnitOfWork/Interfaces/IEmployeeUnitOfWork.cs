using Wolds.Hr.Api.Cr.Data.Interfaces;

namespace Wolds.Hr.Api.Cr.Data.UnitOfWork.Interfaces;

internal interface IEmployeeUnitOfWork
{
    IEmployeeRepository Employee { get; }
    Task SaveChangesAsync();
}
