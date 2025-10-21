using Wolds.Hr.Api.Cr.Library.Dto.Requests;
using Wolds.Hr.Api.Cr.Library.Dto.Responses;

namespace Wolds.Hr.Api.Cr.Service.Interfaces;

internal interface IAuthenticateService
{
    Task<(bool isValid, LoginResponse? authenticated, List<string>? Errors)> AuthenticateAsync(LoginRequest loginRequest, string ipAddress);
}