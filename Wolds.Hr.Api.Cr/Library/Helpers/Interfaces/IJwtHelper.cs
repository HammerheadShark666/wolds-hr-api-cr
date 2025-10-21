using Wolds.Hr.Api.Cr.Domain;

namespace Wolds.Hr.Api.Cr.Library.Helpers.Interfaces;

internal interface IJWTHelper
{
    string GenerateJWTToken(Account account);
}
