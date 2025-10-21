using Wolds.Hr.Api.Cr.Data.Context;
using Wolds.Hr.Api.Cr.Data.Interfaces;
using Wolds.Hr.Api.Cr.Domain;

namespace Wolds.Hr.Api.Cr.Data;

internal sealed class AccountRepository(WoldsHrDbContext woldsHrDbContext) : IAccountRepository
{
    public Account? Get(string email)
    {
        return woldsHrDbContext.Accounts.Where(a => a.Email.Equals(email))
                       .FirstOrDefault();
    }
}