﻿using FluentValidation;
using Wolds.Hr.Api.Cr.Data.UnitOfWork.Interfaces;
using Wolds.Hr.Api.Cr.Domain;
using Wolds.Hr.Api.Cr.Library.Dto.Requests;
using Wolds.Hr.Api.Cr.Library.Dto.Responses;
using Wolds.Hr.Api.Cr.Library.Exceptions;
using Wolds.Hr.Api.Cr.Library.Helpers.Interfaces;
using Wolds.Hr.Api.Cr.Service.Interfaces;

namespace Wolds.Hr.Api.Cr.Service;

internal sealed class AuthenticateService(IValidator<LoginRequest> validator,
                                          IRefreshTokenService refreshTokenService,
                                          IAccountUnitOfWork accountUnitOfWork,
                                          IJWTHelper jwtHelper) : IAuthenticateService
{
    public async Task<(bool isValid, LoginResponse? authenticated, List<string>? Errors)> AuthenticateAsync(LoginRequest loginRequest, string ipAddress)
    {
        var result = await validator.ValidateAsync(loginRequest, options =>
        {
            options.IncludeRuleSets("LoginValidation");
        });
        if (!result.IsValid)
            throw new ValidationException(result.Errors);

        var account = GetAccount(loginRequest.Username);
        var jwtToken = jwtHelper.GenerateJWTToken(account);
        var refreshToken = refreshTokenService.GenerateRefreshToken(ipAddress, account);

        refreshTokenService.RemoveExpiredRefreshTokens(account.Id);
        await refreshTokenService.AddRefreshTokenAsync(refreshToken);

        return (true, new LoginResponse(jwtToken, refreshToken.Token, new Profile(account.FirstName, account.Surname, account.Email)), []);
    }

    private Account GetAccount(string email)
    {
        return accountUnitOfWork.Account.Get(email) ?? throw new AccountNotFoundException();
    }
}