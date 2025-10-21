using Wolds.Hr.Api.Cr.Data.Interfaces;

namespace Wolds.Hr.Api.Cr.Data.UnitOfWork.Interfaces;

internal interface IAccountUnitOfWork
{
    IAccountRepository Account { get; }
    Task SaveChangesAsync();
}
